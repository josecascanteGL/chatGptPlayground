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
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using UnicornShopLegacy.Interfaces;
using EntityState = System.Data.Entity.EntityState;

namespace UnicornShopLegacy.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UnicornController : ApiController
    {
        private IUnishopEntities unishopEntitiesContext;

        public UnicornController(IUnishopEntities databaseContext)
        {
            this.unishopEntitiesContext = databaseContext;
        }

        public UnicornController()
        {
            this.unishopEntitiesContext = new UnishopEntities();
        }

        // GET: api/Unicorn
        public IQueryable<inventory> GetUnicorns()
        {
            return this.unishopEntitiesContext.inventories;
        }

        // GET: api/Unicorn/1d6d0345-b3e5-4e0f-87a3-0a98b9a17073
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> GetUnicorn(Guid id)
        {
            // Find the unicorn with the specified id in the inventory
            inventory unicorn = await this.unishopEntitiesContext.inventories.FindAsync(id);
            if (unicorn == null)
            {
                return this.NotFound(); // Return a 404 Not Found response
            }

            return this.Ok(unicorn); // Return a 200 OK response with the unicorn data
        }

        // PUT: api/Unicorn/1d6d0345-b3e5-4e0f-87a3-0a98b9a17073
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnicorn(Guid id, inventory unicorn)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState); // Return a 400 Bad Request response if the model state is invalid
            }

            if (id != unicorn.unicorn_id)
            {
                return this.BadRequest(); // Return a 400 Bad Request response
            }

            this.unishopEntitiesContext.SetModified(unicorn); // Set the state of the unicorn entity to modified

            try
            {
                await this.unishopEntitiesContext.SaveChangesAsync(); // Save changes to the database
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.UnicornExists(id))
                {
                    return this.NotFound(); // Return a 404 Not Found response if unicorn does not exist
                }
                else
                {
                    throw; // Throw an exception for other cases of database update concurrency issues
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent); // Return a 204 No Content response
        }

        // POST: api/Unicorn
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> PostUnicorn(inventory unicorn)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState); // Return a 400 Bad Request response if the model state is invalid
            }

            unicorn.unicorn_id = Guid.NewGuid(); // Generate a new GUID for the unicorn
            this.unishopEntitiesContext.inventories.Add(unicorn); // Add the unicorn to the inventory
            await this.unishopEntitiesContext.SaveChangesAsync(); // Save changes to the database

            return this.CreatedAtRoute("DefaultApi", new { id = unicorn.unicorn_id }, unicorn); // Return a 201 Created response with the route to access the created unicorn
        }

        // DELETE: api/Unicorn/1d6d0345-b3e5-4e0f-87a3-0a98b9a17073
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> DeleteUnicorn(Guid id)
        {
            // Find the unicorn with the specified id in the inventory
            inventory unicorn = await this.unishopEntitiesContext.inventories.FindAsync(id);
            if (unicorn == null)
            {
                return this.NotFound(); // Return a 404 Not Found response
            }

            this.unishopEntitiesContext.inventories.Remove(unicorn); // Remove the unicorn from the inventory
            await this.unishopEntitiesContext.SaveChangesAsync(); // Save changes to the database

            return this.Ok(unicorn); // Return a 200 OK response with the deleted unicorn data
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unishopEntitiesContext.Dispose(); // Dispose of the entity context when done
            }

            base.Dispose(disposing);
        }

        private bool UnicornExists(Guid id)
        {
            return this.unishopEntitiesContext.inventories.Count(e => e.unicorn_id == id) > 0; // Check if a unicorn with the specified id exists in the inventory
        }
    }
}
