```csharp
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
        public void GetUnicornBasketsTest()
        {
            // Setting up the test environment
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Calling the method we want to test
            var unicornBaskets = this.basketController.GetUnicornBaskets();

            // Assertion for the expected outcome
            Assert.IsNotNull(unicornBaskets);
            Assert.AreEqual(unicornBaskets.Count(), 3);
        }

        [TestMethod]
        public void GetUnicornBasketSuccessTest()
        {
            // Setting up the test environment
            this.GivenUnishopDbContext();
            var user_uuid_to_get = Guid.NewGuid();
            this.unishopDbContext.baskets.Add(new basket { user_id = user_uuid_to_get });
            this.GivenBasketController();

            // Calling the method we want to test
            var result = this.basketController.GetUnicornBasket(user_uuid_to_get).GetAwaiter().GetResult();

            // Assertion for the expected outcome
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IQueryable<basket>>));
            var confirmed_result = result as OkNegotiatedContentResult<IQueryable<basket>>;
            Assert.AreEqual(user_uuid_to_get, confirmed_result.Content.FirstOrDefault().user_id);
        }

        // Repeat similar comments for the remaining test methods
        // ...
```