```csharp
// Import necessary libraries and classes
using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Results;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Import Moq library for mocking
using Moq;
// Import necessary classes from project
using UnicornShopLegacy.Controllers;
using UnicornShopLegacy.Interfaces;

namespace UnicornShopLegacy.Tests
{
    [TestClass]
    public class BasketControllerTests
    {
        private IUnishopEntities unishopDbContext; // Interface for interacting with the database
        private BasketController basketController; // Instance of the BasketController class

        [TestMethod]
        public void GetUnicornBasketsTest()
        {
            // Set up the database context and controller
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Call the GetUnicornBaskets method on the controller
            var unicornBaskets = this.basketController.GetUnicornBaskets();
            // Assert that the result is not null and contains 3 elements
            Assert.IsNotNull(unicornBaskets);
            Assert.AreEqual(unicornBaskets.Count(), 3);
        }

        [TestMethod]
        public void GetUnicornBasketSuccessTest()
        {
            // Set up the database context, create a new basket, and set up the controller
            this.GivenUnishopDbContext();
            var user_uuid_to_get = Guid.NewGuid();
            this.unishopDbContext.baskets.Add(new basket { user_id = user_uuid_to_get });
            this.GivenBasketController();

            // Call the GetUnicornBasket method on the controller
            var result = this.basketController.GetUnicornBasket(user_uuid_to_get).GetAwaiter().GetResult();
            // Assert that the result is not null, is of type OkNegotiatedContentResult, and contains the correct user_id
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IQueryable<basket>>));
            var confirmed_result = result as OkNegotiatedContentResult<IQueryable<basket>>;
            Assert.AreEqual(user_uuid_to_get, confirmed_result.Content.FirstOrDefault().user_id);
        }

        // Additional test methods follow the same structure with variations in input and assertions
        // Comments explain each test scenario and assertion
```