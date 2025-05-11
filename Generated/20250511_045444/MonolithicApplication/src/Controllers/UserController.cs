```csharp
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
            // Constructor to initialize the database context
            this.unishopEntitiesContext = new UnishopEntities();
        }

        public UserController(IUnishopEntities databaseContext)
        {
            // Constructor that accepts an already initialized database context
            this.unishopEntitiesContext = databaseContext;
        }

        public IQueryable<user> GetUsers()
        {
            // Method that returns all users from the database context
            return this.unishopEntitiesContext.users;
        }

        // POST: api/User
        [ResponseType(typeof(user))]
        public async Task<IHttpActionResult> PostUser([FromBody] user user)
        {
            // Check email validity and uniqueness
            var search = from u in this.unishopEntitiesContext.users
                         where u.email == user.email
                         select u;

            if (user.email.IsNullOrWhiteSpace() || !user.email.Contains('@') || !user.email.Contains('.') || search.Count() != 0)
            {
                return this.BadRequest();
            }

            // Hash the user password
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(user.password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            user.password = Convert.ToBase64String(hashBytes);

            // Generate a new unique user ID, add user to context and save changes
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
            // Check if the user exists
            var search = from u in this.unishopEntitiesContext.users
                         where u.email == login.email
                         select u;

            if (search.Count() == 0)
            {
                return this.NotFound();
            }

            var user = search.First();

            // Verify password match
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

            if (!match)
            {
                return this.BadRequest();
            }

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
            return this.unishopEntitiesContext.users.Count(e => e.user_id == id) > 0;
        }
    }
}
```