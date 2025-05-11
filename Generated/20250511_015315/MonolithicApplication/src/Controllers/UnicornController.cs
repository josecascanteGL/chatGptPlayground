```csharp
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
            // Return all inventories from the database context.
            return this.unishopEntitiesContext.inventories;
        }

        // GET: api/Unicorn/1d6d0345-b3e5-4e0f-87a3-0a98b9a17073
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> GetUnicorn(Guid id)
        {
            // Find the unicorn inventory item by its id in the database context.
            inventory unicorn = await this.unishopEntitiesContext.inventories.FindAsync(id);
            if (unicorn == null)
            {
                // If unicorn is not found, return a 404 Not Found status.
                return this.NotFound();
            }

            // Return the unicorn inventory item.
            return this.Ok(unicorn);
        }

        // PUT: api/Unicorn/1d6d0345-b3e5-4e0f-87a3-0a98b9a17073
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnicorn(Guid id, inventory unicorn)
        {
            if (!this.ModelState.IsValid)
            {
                // If the model state is invalid, return a BadRequest response.
                return this.BadRequest(this.ModelState);
            }

            if (id != unicorn.unicorn_id)
            {
                // If the id parameter does not match the unicorn's id, return a BadRequest response.
                return this.BadRequest();
            }

            // Set the state of the unicorn entity to modified in the database context.
            this.unishopEntitiesContext.SetModified(unicorn);

            try
            {
                // Attempt to save changes to the database context.
                await this.unishopEntitiesContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.UnicornExists(id))
                {
                    // If unicorn does not exist in the database, return a NotFound response.
                    return this.NotFound();
                }
                else
                {
                    // If there's a concurrency exception, rethrow it.
                    throw;
                }
            }

            // Return a NoContent status on successful update.
            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Unicorn
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> PostUnicorn(inventory unicorn)
        {
            if (!this.ModelState.IsValid)
            {
                // If the model state is invalid, return a BadRequest response.
                return this.BadRequest(this.ModelState);
            }

            // Generate a new unique id for the unicorn entity.
            unicorn.unicorn_id = Guid.NewGuid();
            // Add the new unicorn entity to the database context.
            this.unishopEntitiesContext.inventories.Add(unicorn);
            // Save changes to the database context.
            await this.unishopEntitiesContext.SaveChangesAsync();

            // Return a CreatedAtRoute response with the newly created unicorn.
            return this.CreatedAtRoute("DefaultApi", new { id = unicorn.unicorn_id }, unicorn);
        }

        // DELETE: api/Unicorn/1d6d0345-b3e5-4e0f-87a3-0a98b9a17073
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> DeleteUnicorn(Guid id)
        {
            // Find the unicorn inventory item by its id in the database context.
            inventory unicorn = await this.unishopEntitiesContext.inventories.FindAsync(id);
            if (unicorn == null)
            {
                // If unicorn is not found, return a NotFound response.
                return this.NotFound();
            }

            // Remove the unicorn entity from the database context.
            this.unishopEntitiesContext.inventories.Remove(unicorn);
            // Save changes to the database context.
            await this.unishopEntitiesContext.SaveChangesAsync();

            // Return the deleted unicorn entity.
            return this.Ok(unicorn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose the database context if disposing is true.
                this.unishopEntitiesContext.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool UnicornExists(Guid id)
        {
            // Check if a unicorn entity with the given id exists in the database context.
            return this.unishopEntitiesContext.inventories.Count(e => e.unicorn_id == id) > 0;
        }
    }
}
```