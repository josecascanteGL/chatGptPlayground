```csharp
/*
 * The UnicornController class is a controller for handling CRUD operations on unicorn inventory items. It interacts with a database context implementing the IUnishopEntities interface.
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
            // Returns a queryable collection of all unicorn inventory items from the database context.
            return this.unishopEntitiesContext.inventories;
        }

        // GET: api/Unicorn/1d6d0345-b3e5-4e0f-87a3-0a98b9a17073
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> GetUnicorn(Guid id)
        {
            // Retrieves a specific unicorn inventory item by its unique identifier.
            inventory unicorn = await this.unishopEntitiesContext.inventories.FindAsync(id);
            if (unicorn == null)
            {
                // Returns a 404 Not Found response if the specified unicorn is not found.
                return this.NotFound();
            }

            // Returns a 200 OK response with the unicorn inventory item.
            return this.Ok(unicorn);
        }

        // PUT: api/Unicorn/1d6d0345-b3e5-4e0f-87a3-0a98b9a17073
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnicorn(Guid id, inventory unicorn)
        {
            if (!this.ModelState.IsValid)
            {
                // Returns a 400 Bad Request response if the model state is not valid.
                return this.BadRequest(this.ModelState);
            }

            if (id != unicorn.unicorn_id)
            {
                // Returns a 400 Bad Request response if the specified ID does not match the unicorn's ID.
                return this.BadRequest();
            }

            // Sets the modified state of the unicorn inventory item in the database context.
            this.unishopEntitiesContext.SetModified(unicorn);

            try
            {
                // Saves the changes to the database context.
                await this.unishopEntitiesContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.UnicornExists(id))
                {
                    // Returns a 404 Not Found response if the unicorn does not exist.
                    return this.NotFound();
                }
                else
                {
                    // Throws an exception if there is a concurrency issue.
                    throw;
                }
            }

            // Returns a 204 No Content response after a successful PUT operation.
            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Unicorn
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> PostUnicorn(inventory unicorn)
        {
            if (!this.ModelState.IsValid)
            {
                // Returns a 400 Bad Request response if the model state is not valid.
                return this.BadRequest(this.ModelState);
            }

            // Generates a new GUID as the ID for the unicorn inventory item.
            unicorn.unicorn_id = Guid.NewGuid();

            // Adds the unicorn inventory item to the database context.
            this.unishopEntitiesContext.inventories.Add(unicorn);

            // Saves the changes to the database context.
            await this.unishopEntitiesContext.SaveChangesAsync();

            // Returns a 201 Created response with the created unicorn inventory item.
            return this.CreatedAtRoute("DefaultApi", new { id = unicorn.unicorn_id }, unicorn);
        }

        // DELETE: api/Unicorn/1d6d0345-b3e5-4e0f-87a3-0a98b9a17073
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> DeleteUnicorn(Guid id)
        {
            // Retrieves and removes a specific unicorn inventory item by its unique identifier.
            inventory unicorn = await this.unishopEntitiesContext.inventories.FindAsync(id);
            if (unicorn == null)
            {
                // Returns a 404 Not Found response if the specified unicorn is not found.
                return this.NotFound();
            }

            // Removes the unicorn inventory item from the database context.
            this.unishopEntitiesContext.inventories.Remove(unicorn);

            // Saves the changes to the database context.
            await this.unishopEntitiesContext.SaveChangesAsync();

            // Returns a 200 OK response with the deleted unicorn inventory item.
            return this.Ok(unicorn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Disposes the database context when the controller is being disposed.
                this.unishopEntitiesContext.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool UnicornExists(Guid id)
        {
            // Checks if a unicorn inventory item with the specified ID exists in the database context.
            return this.unishopEntitiesContext.inventories.Count(e => e.unicorn_id == id) > 0;
        }
    }
}
```