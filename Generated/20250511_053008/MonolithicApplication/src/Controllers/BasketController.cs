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
            this.unishopEntitiesContext = new UnishopEntities(); // Initializes the database context with default constructor
        }

        public BasketController(IUnishopEntities databaseContext)
        {
            this.unishopEntitiesContext = databaseContext; // Initializes the database context with dependency injection
        }

        // GET: api/Basket
        public IQueryable<basket> GetUnicornBaskets()
        {
            return this.unishopEntitiesContext.baskets; // Retrieves all basket items from the database
        }

        // GET: api/Basket/f29b70d8-2994-4cea-861e-61903801dd98
        [ResponseType(typeof(basket))]
        public async Task<IHttpActionResult> GetUnicornBasket(Guid id)
        {
            var unicornBasket = from ub in this.unishopEntitiesContext.baskets
                                          where ub.user_id == id
                                                 select ub; // Retrieves a specific basket item based on user id

            if (unicornBasket.Count() == 0) // If no item is found, return NotFound response
            {
                return this.NotFound();
            }

            return this.Ok(unicornBasket); // Return the basket item if found
        }

        // PUT: api/Basket/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUnicornBasket(Guid id, basket unicornBasket)
        {
            if (!this.ModelState.IsValid) // Validates the model state
            {
                return this.BadRequest(this.ModelState); // If model state is not valid, return BadRequest response
            }

            if (id != unicornBasket.basket_id)
            {
                return this.BadRequest(); // If the id provided does not match the item's id, return BadRequest response
            }

            this.unishopEntitiesContext.SetModified(unicornBasket); // Sets the basket item to Modified state

            try
            {
                await this.unishopEntitiesContext.SaveChangesAsync(); // Saves changes to the database
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.UnicornBasketExists(id)) // Checks if the basket item exists
                {
                    return this.NotFound(); // If the item does not exist, return NotFound response
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent); // Return NoContent response
        }

        // POST: api/Basket
        [ResponseType(typeof(basket))]
        public async Task<IHttpActionResult> PostUnicornBasket(basket unicornBasket)
        {
            if (!this.ModelState.IsValid) // Validates the model state
            {
                return this.BadRequest(this.ModelState); // If model state is not valid, return BadRequest response
            }

            unicornBasket.basket_id = Guid.NewGuid(); // Generates a new unique id for the basket item
            this.unishopEntitiesContext.baskets.Add(unicornBasket); // Adds the new basket item to the database
            await this.unishopEntitiesContext.SaveChangesAsync(); // Saves changes to the database

            return this.CreatedAtRoute("DefaultApi", new { id = unicornBasket.basket_id }, unicornBasket); // Return CreatedAtRoute response
        }

        // DELETE: api/Basket/1d6d0345-b3e5-4e0f-87a3-0a98b9a17073
        [ResponseType(typeof(basket))]
        public async Task<IHttpActionResult> DeleteUnicornBasket(Guid id)
        {
            basket unicornBasket = await this.unishopEntitiesContext.baskets.FindAsync(id); // Retrieves the basket item by id
            if (unicornBasket == null) // If the item does not exist, return NotFound response
            {
                return this.NotFound();
            }

            this.unishopEntitiesContext.baskets.Remove(unicornBasket); // Removes the basket item from the database
            await this.unishopEntitiesContext.SaveChangesAsync(); // Saves changes to the database

            return this.Ok(unicornBasket); // Return the deleted basket item
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unishopEntitiesContext.Dispose(); // Dispose the database context
            }

            base.Dispose(disposing);
        }

        private bool UnicornBasketExists(Guid id)
        {
            return this.unishopEntitiesContext.baskets.Count(e => e.basket_id == id) > 0; // Checks if the basket item exists based on id
        }
    }
}
```