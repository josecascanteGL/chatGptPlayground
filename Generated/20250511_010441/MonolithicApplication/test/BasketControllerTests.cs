```c#
    [TestClass]
    public class BasketControllerTests
    {
        private IUnishopEntities unishopDbContext;
        private BasketController basketController;

        [TestMethod]
        public void GetUnicornBasketsTest()
        {
            // Arrange
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Act
            var unicornBaskets = this.basketController.GetUnicornBaskets();

            // Assert
            Assert.IsNotNull(unicornBaskets);
            Assert.AreEqual(unicornBaskets.Count(), 3);
        }

        [TestMethod]
        public void GetUnicornBasketSuccessTest()
        {
            // Arrange
            this.GivenUnishopDbContext();
            var user_uuid_to_get = Guid.NewGuid();
            this.unishopDbContext.baskets.Add(new basket { user_id = user_uuid_to_get });
            this.GivenBasketController();

            // Act
            var result = this.basketController.GetUnicornBasket(user_uuid_to_get).GetAwaiter().GetResult();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IQueryable<basket>>));
            var confirmed_result = result as OkNegotiatedContentResult<IQueryable<basket>>;
            Assert.AreEqual(user_uuid_to_get, confirmed_result.Content.FirstOrDefault().user_id);
        }

        [TestMethod]
        public void GetUnicornBasketWithInvalidUUIDTest()
        {
            // Arrange
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Act
            var user_uuid_to_get = Guid.NewGuid();
            var result = this.basketController.GetUnicornBasket(user_uuid_to_get).GetAwaiter().GetResult();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutUnicornBasketSuccessTest()
        {
            // Arrange
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Act
            var basket_uuid_to_put = Guid.NewGuid();
            var result = this.basketController.PutUnicornBasket(basket_uuid_to_put, new basket { basket_id = basket_uuid_to_put }).GetAwaiter().GetResult();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            var confirmed_result = result as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.NoContent, confirmed_result.StatusCode);
        }

        [TestMethod]
        public void PutUnicornBasketTestIdsNotMatching()
        {
            // Arrange
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Act
            var result = this.basketController.PutUnicornBasket(Guid.NewGuid(), new basket { basket_id = Guid.NewGuid() }).GetAwaiter().GetResult();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void PostUnicornBasketSuccessTest()
        {
            // Arrange
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Act
            var basket = new basket { basket_id = Guid.NewGuid() };
            var result = this.basketController.PostUnicornBasket(basket).GetAwaiter().GetResult();

            // Assert
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
            // Arrange
            this.GivenUnishopDbContext();
            this.GivenBasketController();

            // Act
            this.basketController.ModelState.AddModelError("invalidModelFakeError", "Fake model error for testing");
            var result = this.basketController.PostUnicornBasket(new basket() { }).GetAwaiter().GetResult();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void DeleteUnicornBasketTest()
        {
            // Arrange
            this.GivenUnishopDbContext();
            this.GivenBasketController();
            var uuid_to_delete = Guid.NewGuid();
            this.unishopDbContext.baskets.Add(new basket { basket_id = uuid_to_delete });

            // Act
            var result = this.basketController.DeleteUnicornBasket(uuid_to_delete).GetAwaiter().GetResult();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<basket>));
            var confirmed_result = result as OkNegotiatedContentResult<basket>;
            Assert.AreEqual(uuid_to_delete, confirmed_result.Content.basket_id);
        }

        public void DeleteInvalidUnicornBasketTest()
        {
            // Arrange
            this.GivenUnishopDbContext();
            this.GivenBasketController();
            var uuid_to_delete = Guid.NewGuid();

            // Act
            var result = this.basketController.DeleteUnicornBasket(uuid_to_delete).GetAwaiter().GetResult();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        private void GivenUnishopDbContext()
        {
            // Creating a fake database context
            var fakeSet = new FakeBasketDbSet();
            fakeSet.AddRange(new[] { new basket { }, new basket { }, new basket { } });

            // Mocking the database context
            var mock = new Mock<IUnishopEntities>();
            mock.As<IDisposable>().Setup(x => x.Dispose());
            mock.Setup(x => x.baskets).Returns(fakeSet);
            mock.Setup(x => x.SetModified(It.IsAny<object>()));

            this.unishopDbContext = mock.Object;
        }

        private void GivenBasketController()
        {
            // Creating an instance of BasketController
            this.basketController = new BasketController(this.unishopDbContext);
        }
    }
}
```