```csharp
        [TestClass]
        public class UnicornControllerTests
        {
            // Declaring the necessary variables for testing
            private IUnishopEntities unishopDbContext;
            private UnicornController unicornController;
            private Mock<IUnishopEntities> mockedUnicornEntities;
            
            // Initializing the test setup
            [TestInitialize]
            public void Init()
            {
                this.GivenUnishopDbContext();
                this.GivenUnicornController();
            }

            // Testing GetUnicorns method
            [TestMethod]
            public void GetUnicorns_WhenCalled_ReturnTwoUnicorns()
            {
                // Fetching unicorns and asserting the count
                var unicorns = this.unicornController.GetUnicorns();
                unicorns.Should().HaveCount(2, "because 2 unicorns are added to DbContext.Unicorns");
            }

            // Testing GetUnicorns method return type
            [TestMethod]
            public void GetUnicorns_WhenCalled_ReturnIQueriableOfUnicorn()
            {
                // Fetching unicorns and asserting the type
                var unicorns = this.unicornController.GetUnicorns();
                Assert.IsInstanceOfType(unicorns, typeof(IQueryable<inventory>));
            }

            // Testing GetUnicorn method for existing unicorn
            [TestMethod]
            public async Task GetUnicorn_ExistingUnicornId_ReturnOkResult()
            {
                // Creating a new unicorn, adding it to database, and fetching it
                var guid = Guid.NewGuid();
                this.unishopDbContext.inventories.Add(new inventory { unicorn_id = guid });
                var actionResult = await this.unicornController.GetUnicorn(guid);
                var contentResult = actionResult as OkNegotiatedContentResult<inventory>;
                
                // Validating the result
                Assert.IsNotNull(contentResult);
                Assert.IsNotNull(contentResult.Content);
                Assert.AreEqual(guid, contentResult.Content.unicorn_id);
            }
            
            // More test methods continue... 
```