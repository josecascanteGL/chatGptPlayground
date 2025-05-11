/*
 * The following code defines a Web API controller for managing unicorn inventory.
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

        // Constructor that takes a database context implementing IUnishopEntities
        public UnicornController(IUnishopEntities databaseContext)
        {
            this.unishopEntitiesContext = databaseContext;
        }

        // Default constructor that creates a new UnishopEntities database context
        public UnicornController()
        {
            this.unishopEntitiesContext = new UnishopEntities();
        }

        // GET: api/Unicorn - Returns all unicorn inventories
        public IQueryable<inventory> GetUnicorns()
        {
            return this.unishopEntitiesContext.inventories;
        }

        // GET: api/Unicorn/{id} - Returns the unicorn inventory with the specified ID
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> GetUnicorn(Guid id)
        {
            inventory unicorn = await this.unishopEntitiesContext.inventories.FindAsync(id);
            if (unicorn == null)
            {
                return this.NotFound();
            }

            return this.Ok(unicorn);
        }

        // PUT: api/Unicorn/{id} - Updates the unicorn inventory with the specified ID
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnicorn(Guid id, inventory unicorn)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != unicorn.unicorn_id)
            {
                return this.BadRequest();
            }

            // Set the entity state to modified
            this.unishopEntitiesContext.SetModified(unicorn);

            try
            {
                // Save changes to the database asynchronously
                await this.unishopEntitiesContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.UnicornExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Unicorn - Creates a new unicorn inventory
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> PostUnicorn(inventory unicorn)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            // Generate a new GUID for the unicorn inventory
            unicorn.unicorn_id = Guid.NewGuid();
            this.unishopEntitiesContext.inventories.Add(unicorn);
            // Save changes to the database asynchronously
            await this.unishopEntitiesContext.SaveChangesAsync();

            return this.CreatedAtRoute("DefaultApi", new { id = unicorn.unicorn_id }, unicorn);
        }

        // DELETE: api/Unicorn/{id} - Deletes the unicorn inventory with the specified ID
        [ResponseType(typeof(inventory))]
        public async Task<IHttpActionResult> DeleteUnicorn(Guid id)
        {
            inventory unicorn = await this.unishopEntitiesContext.inventories.FindAsync(id);
            if (unicorn == null)
            {
                return this.NotFound();
            }

            this.unishopEntitiesContext.inventories.Remove(unicorn);
            // Save changes to the database asynchronously
            await this.unishopEntitiesContext.SaveChangesAsync();

            return this.Ok(unicorn);
        }

        // Dispose of the database context
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unishopEntitiesContext.Dispose();
            }

            base.Dispose(disposing);
        }

        // Check if a unicorn with the specified ID exists in the inventory
        private bool UnicornExists(Guid id)
        {
            return this.unishopEntitiesContext.inventories.Count(e => e.unicorn_id == id) > 0;
        }
    }
}