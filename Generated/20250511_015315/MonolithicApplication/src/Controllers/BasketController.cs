```c#
using System;
using System.Data.Entity;
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
    public class BasketController : ApiController
    {
        private IUnishopEntities unishopEntitiesContext;

        public BasketController()
        {
            // Constructor initializes a new instance of UnishopEntities as the database context
            this.unishopEntitiesContext = new UnishopEntities();
        }

        public BasketController(IUnishopEntities databaseContext)
        {
            // Constructor that allows injecting a custom database context
            this.unishopEntitiesContext = databaseContext;
        }

        // GET: api/Basket - Retrieves all unicorn baskets
        public IQueryable<basket> GetUnicornBaskets()
        {
            // Returns all unicorn baskets from the database context
            return this.unishopEntitiesContext.baskets;
        }

        // GET: api/Basket/f29b70d8-2994-4cea-861e-61903801dd98 - Retrieves a specific unicorn basket by user ID
        [ResponseType(typeof(basket))]
        public async Task<IHttpActionResult> GetUnicornBasket(Guid id)
        {
            // Queries the database for the unicorn basket matching the user ID
            var unicornBasket = from ub in this.unishopEntitiesContext.baskets
                                where ub.user_id == id
                                select ub;

            // Checks if the basket exists and returns the result
            if (unicornBasket.Count() == 0)
            {
                return this.NotFound();
            }

            return this.Ok(unicornBasket);
        }

        // PUT: api/Basket/5 - Updates an existing unicorn basket
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnicornBasket(Guid id, basket unicornBasket)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            // Checks if the request ID matches the basket ID
            if (id != unicornBasket.basket_id)
            {
                return this.BadRequest();
            }

            // Sets the state of the basket entity to modified
            this.unishopEntitiesContext.SetModified(unicornBasket);

            try
            {
                // Attempts to save changes to the database
                await this.unishopEntitiesContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.UnicornBasketExists(id))
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

        // POST: api/Basket - Creates a new unicorn basket
        [ResponseType(typeof(basket))]
        public async Task<IHttpActionResult> PostUnicornBasket(basket unicornBasket)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            // Generates a new GUID for the basket ID
            unicornBasket.basket_id = Guid.NewGuid();

            // Adds the new unicorn basket to the context and saves changes
            this.unishopEntitiesContext.baskets.Add(unicornBasket);
            await this.unishopEntitiesContext.SaveChangesAsync();

            return this.CreatedAtRoute("DefaultApi", new { id = unicornBasket.basket_id }, unicornBasket);
        }

        // DELETE: api/Basket/1d6d0345-b3e5-4e0f-87a3-0a98b9a17073 - Deletes a unicorn basket by ID
        [ResponseType(typeof(basket))]
        public async Task<IHttpActionResult> DeleteUnicornBasket(Guid id)
        {
            // Finds the unicorn basket entity with the given ID
            basket unicornBasket = await this.unishopEntitiesContext.baskets.FindAsync(id);
            if (unicornBasket == null)
            {
                return this.NotFound();
            }

            // Removes the unicorn basket from the context and saves changes
            this.unishopEntitiesContext.baskets.Remove(unicornBasket);
            await this.unishopEntitiesContext.SaveChangesAsync();

            return this.Ok(unicornBasket);
        }

        // Disposes the database context when done
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unishopEntitiesContext.Dispose();
            }

            base.Dispose(disposing);
        }

        // Helper method to check if a unicorn basket with a specific ID exists
        private bool UnicornBasketExists(Guid id)
        {
            return this.unishopEntitiesContext.baskets.Count(e => e.basket_id == id) > 0;
        }
    }
}
```