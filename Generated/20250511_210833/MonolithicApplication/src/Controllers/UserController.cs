/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * SPDX-License-Identifier: MIT-0
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify,
 * merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using UnicornShopLegacy.Interfaces;
using EntityState = System.Data.Entity.EntityState;

namespace UnicornShopLegacy.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private IUnishopEntities unishopEntitiesContext;

        public UserController()
        {
            // Constructor initializes the database context
            this.unishopEntitiesContext = new UnishopEntities();
        }

        public UserController(IUnishopEntities databaseContext)
        {
            // Constructor allowing injection of database context
            this.unishopEntitiesContext = databaseContext;
        }

        public IQueryable<user> GetUsers()
        {
            // Get all users from the database
            return this.unishopEntitiesContext.users;
        }

        // POST: api/User
        [ResponseType(typeof(user))]
        public async Task<IHttpActionResult> PostUser([FromBody] user user)
        {
            // Query for existing users with the same email
            var search = from u in this.unishopEntitiesContext.users
                         where u.email == user.email
                         select u;

            // Validate email format and uniqueness
            if (user.email.IsNullOrWhiteSpace() || !user.email.Contains('@') || !user.email.Contains('.') || search.Count() != 0)
            {
                return this.BadRequest();
            }

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(user.password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            user.password = Convert.ToBase64String(hashBytes);

            user.user_id = Guid.NewGuid();
            this.unishopEntitiesContext.users.Add(user);
            await this.unishopEntitiesContext.SaveChangesAsync();

            return this.CreatedAtRoute("DefaultApi", new { id = user.user_id }, user);
        }

        // POST: api/user/login
        [Route("api/user/login")]
        [HttpPost]
        public async Task<IHttpActionResult> PostLogin([FromBody] user login)
        {
            // Query for the user with the provided email
            var search = from u in this.unishopEntitiesContext.users
                         where u.email == login.email
                         select u;

            // Check if user with email exists
            if (search.Count() == 0)
            {
                return this.NotFound();
            }

            var user = search.First();

            byte[] hashBytes = Convert.FromBase64String(user.password);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(login.password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            bool match = true;
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    match = false;
                }
            }

            // Check if password matches the stored hash
            if (!match)
            {
                return this.BadRequest();
            }

            // Return user details upon successful login
            return this.Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unishopEntitiesContext.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool UserExists(Guid id)
        {
            // Check if a user with the given ID exists in the database
            return this.unishopEntitiesContext.users.Count(e => e.user_id == id) > 0;
        }
    }
}