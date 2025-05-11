```csharp
// Import necessary libraries
using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Results;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnicornShopLegacy.Controllers;
using UnicornShopLegacy.Interfaces;

namespace UnicornShopLegacy.Tests
{
    [TestClass]
    public class BasketControllerTests
    {
        private IUnishopEntities unishopDbContext;
        private BasketController basketController;

        [TestMethod]
        // Test to get unicorn baskets
        public void GetUnicornBasketsTest()
        {
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Get the unicorn baskets from the controller and perform assertions
            var unicornBaskets = this.basketController.GetUnicornBaskets();
            Assert.IsNotNull(unicornBaskets);
            Assert.AreEqual(unicornBaskets.Count(), 3);
        }

        [TestMethod]
        // Test to get unicorn basket successfully
        public void GetUnicornBasketSuccessTest()
        {
            this.GivenUnishopDbContext();
            var user_uuid_to_get = Guid.NewGuid();
            this.unishopDbContext.baskets.Add(new basket { user_id = user_uuid_to_get });
            this.GivenBasketController();

            // Get the unicorn basket for a specific user UUID and perform assertions
            var result = this.basketController.GetUnicornBasket(user_uuid_to_get).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IQueryable<basket>>));
            var confirmed_result = result as OkNegotiatedContentResult<IQueryable<basket>>;
            Assert.AreEqual(user_uuid_to_get, confirmed_result.Content.FirstOrDefault().user_id);
        }

        [TestMethod]
        // Test to get unicorn basket with an invalid UUID
        public void GetUnicornBasketWithInvalidUUIDTest()
        {
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            var user_uuid_to_get = Guid.NewGuid();

            // Get the unicorn basket for an invalid user UUID and perform assertions
            var result = this.basketController.GetUnicornBasket(user_uuid_to_get).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        // Test to update unicorn basket successfully
        public void PutUnicornBasketSuccessTest()
        {
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            var basket_uuid_to_put = Guid.NewGuid();

            // Update the unicorn basket and perform assertions
            var result = this.basketController.PutUnicornBasket(basket_uuid_to_put, new basket { basket_id = basket_uuid_to_put }).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            var confirmed_result = result as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.NoContent, confirmed_result.StatusCode);
        }

        [TestMethod]
        // Test to update unicorn basket with mismatching IDs
        public void PutUnicornBasketTestIdsNotMatching()
        {
            this.GivenUnishopDbContext();
            this.GivenBasketController();
            var result = this.basketController.PutUnicornBasket(Guid.NewGuid(), new basket { basket_id = Guid.NewGuid() }).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        // Test to create a new unicorn basket successfully
        public void PostUnicornBasketSuccessTest()
        {
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            var basket = new basket { basket_id = Guid.NewGuid() };

            // Create a new unicorn basket and perform assertions
            var result = this.basketController.PostUnicornBasket(basket).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<basket>));
            var confirmed_result = result as CreatedAtRouteNegotiatedContentResult<basket>;
            Assert.AreEqual(confirmed_result.RouteName, "DefaultApi");
            Assert.AreEqual(confirmed_result.RouteValues["id"], confirmed_result.Content.basket_id);
            Assert.AreEqual(confirmed_result.Content.basket_id, basket.basket_id);
        }

        [TestMethod]
        // Test to create a new unicorn basket with an invalid model
        public void PostUnicornBasketInvalidModelTest()
        {
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            this.basketController.ModelState.AddModelError("invalidModelFakeError", "Fake model error for testing");

            // Create a new unicorn basket with an invalid model and perform assertions
            var result = this.basketController.PostUnicornBasket(new basket() { }).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        // Test to delete a unicorn basket
        public void DeleteUnicornBasketTest()
        {
            this.GivenUnishopDbContext();
            this.GivenBasketController();
            var uuid_to_delete = Guid.NewGuid();
            this.unishopDbContext.baskets.Add(new basket { basket_id = uuid_to_delete });

            // Delete the unicorn basket and perform assertions
            var result = this.basketController.DeleteUnicornBasket(uuid_to_delete).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<basket>));
            var confirmed_result = result as OkNegotiatedContentResult<basket>;
            Assert.AreEqual(uuid_to_delete, confirmed_result.Content.basket_id);
        }

        // Test to delete an invalid unicorn basket
        public void DeleteInvalidUnicornBasketTest()
        {
            this.GivenUnishopDbContext();
            this.GivenBasketController();
            var uuid_to_delete = Guid.NewGuid();

            // Delete an invalid unicorn basket and perform assertions
            var result = this.basketController.DeleteUnicornBasket(uuid_to_delete).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        // Setup the fake unicorn shop database context
        private void GivenUnishopDbContext()
        {
            var fakeSet = new FakeBasketDbSet();
            fakeSet.AddRange(new[] { new basket { }, new basket { }, new basket { } });
            var mock = new Mock<IUnishopEntities>();
            mock.As<IDisposable>().Setup(x => x.Dispose());
            mock.Setup(x => x.baskets).Returns(fakeSet);
            mock.Setup(x => x.SetModified(It.IsAny<object>()));

            // Set the database context to the configured mock
            this.unishopDbContext = mock.Object;
        }

        // Setup the basket controller with the configured database context
        private void GivenBasketController()
        {
            this.basketController = new BasketController(this.unishopDbContext);
        }
    }
}
```