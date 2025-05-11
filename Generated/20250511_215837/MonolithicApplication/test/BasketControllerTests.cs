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
            // Setting up the test data
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Calling the method under test
            var unicornBaskets = this.basketController.GetUnicornBaskets();

            // Asserting the results
            Assert.IsNotNull(unicornBaskets);
            Assert.AreEqual(unicornBaskets.Count(), 3);
        }

        [TestMethod]
        public void GetUnicornBasketSuccessTest()
        {
            // Setting up the test data
            this.GivenUnishopDbContext();
            var user_uuid_to_get = Guid.NewGuid();
            this.unishopDbContext.baskets.Add(new basket { user_id = user_uuid_to_get });
            this.GivenBasketController();

            // Calling the method under test
            var result = this.basketController.GetUnicornBasket(user_uuid_to_get).GetAwaiter().GetResult();

            // Asserting the results
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IQueryable<basket>>));
            var confirmed_result = result as OkNegotiatedContentResult<IQueryable<basket>>;
            Assert.AreEqual(user_uuid_to_get, confirmed_result.Content.FirstOrDefault().user_id);
        }

        [TestMethod]
        public void GetUnicornBasketWithInvalidUUIDTest()
        {
            // Setting up the test data
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            var user_uuid_to_get = Guid.NewGuid();

            // Calling the method under test
            var result = this.basketController.GetUnicornBasket(user_uuid_to_get).GetAwaiter().GetResult();

            // Asserting the results
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutUnicornBasketSuccessTest()
        {
            // Setting up the test data
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            var basket_uuid_to_put = Guid.NewGuid();

            // Calling the method under test
            var result = this.basketController.PutUnicornBasket(basket_uuid_to_put, new basket { basket_id = basket_uuid_to_put }).GetAwaiter().GetResult();

            // Asserting the results
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            var confirmed_result = result as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.NoContent, confirmed_result.StatusCode);
        }

        [TestMethod]
        public void PutUnicornBasketTestIdsNotMatching()
        {
            // Setting up the test data
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Calling the method under test
            var result = this.basketController.PutUnicornBasket(Guid.NewGuid(), new basket { basket_id = Guid.NewGuid() }).GetAwaiter().GetResult();

            // Asserting the results
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void PostUnicornBasketSuccessTest()
        {
            // Setting up the test data
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            var basket = new basket { basket_id = Guid.NewGuid() };

            // Calling the method under test
            var result = this.basketController.PostUnicornBasket(basket).GetAwaiter().GetResult();

            // Asserting the results
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<basket>));
            var confirmed_result = result as CreatedAtRouteNegotiatedContentResult<basket>;
            Assert.AreEqual(confirmed_result.RouteName, "DefaultApi");
            Assert.AreEqual(confirmed_result.RouteValues["id"], confirmed_result.Content.basket_id);
            Assert.AreEqual(confirmed_result.Content.basket_id, basket.basket_id);
        }

        [TestMethod]
        public void PostUnicornBasketInvalidModelTest()
        {
            // Setting up the test data
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Simulate invalid model state
            this.basketController.ModelState.AddModelError("invalidModelFakeError", "Fake model error for testing");

            // Calling the method under test
            var result = this.basketController.PostUnicornBasket(new basket() { }).GetAwaiter().GetResult();

            // Asserting the results
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void DeleteUnicornBasketTest()
        {
            // Setting up the test data
            this.GivenUnishopDbContext();
            this.GivenBasketController();
            var uuid_to_delete = Guid.NewGuid();
            this.unishopDbContext.baskets.Add(new basket { basket_id = uuid_to_delete });

            // Calling the method under test
            var result = this.basketController.DeleteUnicornBasket(uuid_to_delete).GetAwaiter().GetResult();

            // Asserting the results
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<basket>));
            var confirmed_result = result as OkNegotiatedContentResult<basket>;
            Assert.AreEqual(uuid_to_delete, confirmed_result.Content.basket_id);
        }

        public void DeleteInvalidUnicornBasketTest()
        {
            // Setting up the test data
            this.GivenUnishopDbContext();
            this.GivenBasketController();
            var uuid_to_delete = Guid.NewGuid();

            // Calling the method under test
            var result = this.basketController.DeleteUnicornBasket(uuid_to_delete).GetAwaiter().GetResult();

            // Asserting the results
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        private void GivenUnishopDbContext()
        {
            // Creating a fake DbSet and mocking the IUnishopEntities
            var fakeSet = new FakeBasketDbSet();
            fakeSet.AddRange(new[] { new basket { }, new basket { }, new basket { } });
            var mock = new Mock<IUnishopEntities>();
            mock.As<IDisposable>().Setup(x => x.Dispose());
            mock.Setup(x => x.baskets).Returns(fakeSet);
            mock.Setup(x => x.SetModified(It.IsAny<object>()));

            this.unishopDbContext = mock.Object;
        }

        private void GivenBasketController()
        {
            // Creating a new instance of BasketController with the mocked IUnishopEntities
            this.basketController = new BasketController(this.unishopDbContext);
        }
    }
}
