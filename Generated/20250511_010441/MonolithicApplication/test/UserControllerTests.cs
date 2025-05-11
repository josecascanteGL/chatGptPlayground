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
    public class UserControllerTests
    {
        private IUnishopEntities unishopDbContext;
        private UserController userController;

        // Test method to get users
        [TestMethod]
        public void GetUsersTest()
        {
            this.GivenUnishopDbContext(); // Setup fake database context
            this.GivenUserController(); // Create user controller instance

            var users = this.userController.GetUsers(); // Retrieve users
            Assert.IsNotNull(users); // Ensure users are not null
            Assert.AreEqual(users.Count(), 3); // Check the count of users
        }

        // Test method for successful user signup
        [TestMethod]
        public void SignUPTestSuccess()
        {
            this.GivenUnishopDbContext(); // Setup fake database context
            this.GivenUserController(); // Create user controller instance

            var user = new user { user_id = Guid.NewGuid(), email = "456@gmail.com", password = "123456" }; // Create a new user
            var result = this.userController.PostUser(user).GetAwaiter().GetResult(); // Execute user signup
            Assert.IsNotNull(result); // Ensure result is not null

            // Validate the result returned
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<user>));
            var confirmed_result = result as CreatedAtRouteNegotiatedContentResult<user>;
            Assert.AreEqual(confirmed_result.RouteName, "DefaultApi");
            Assert.AreEqual(confirmed_result.RouteValues["id"], confirmed_result.Content.user_id);
            Assert.AreEqual(confirmed_result.Content.user_id, user.user_id);

            //this.unishopDbContext.user.Remove(confirmed_result.Content); // Cleanup - Remove the user
        }

        // Test method for duplicate email signup failure
        [TestMethod]
        public void SignUpTestDuplicateEmail_ShouldFail()
        {
            this.GivenUnishopDbContext(); // Setup fake database context
            this.GivenUserController(); // Create user controller instance

            var user = new user { user_id = Guid.NewGuid(), email = "qwertyuio@gmail.com", password = "123456" }; // Create a new user
            var result = this.userController.PostUser(user).GetAwaiter().GetResult(); // Execute user signup
            var confirmed_result = result as CreatedAtRouteNegotiatedContentResult<user>; // Get the confirmed result

            result = this.userController.PostUser(user).GetAwaiter().GetResult(); // Attempt to signup with duplicate email
            Assert.IsNotNull(result); // Ensure result is not null
            Assert.IsInstanceOfType(result, typeof(BadRequestResult)); // Expect a BadRequest in case of duplicate email
        }

        // Test method for successful user login
        [TestMethod]
        public void LoginTestSuccess()
        {
            this.GivenUnishopDbContext(); // Setup fake database context
            this.GivenUserController(); // Create user controller instance

            var user_temp = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // Create a new user
            this.userController.PostUser(user_temp).GetAwaiter().GetResult(); // Signup the user

            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // New user with same email
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult(); // Execute user login
            Assert.IsNotNull(result); // Ensure result is not null

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<user>)); // Expect an Ok result
        }

        // Test method for login failure due to user not existing
        [TestMethod]
        public void LoginTestUserNotExist_ShouldFail()
        {
            this.GivenUnishopDbContext(); // Setup fake database context
            this.GivenUserController(); // Create user controller instance

            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // New user
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult(); // Attempt login
            Assert.IsNotNull(result); // Ensure result is not null
            Assert.IsInstanceOfType(result, typeof(NotFoundResult)); // Expect NotFound for non-existing user
        }

        // Test method for login failure due to incorrect password
        [TestMethod]
        public void LoginTestPasswordIncorrect_ShouldFail()
        {
            this.GivenUnishopDbContext(); // Setup fake database context
            this.GivenUserController(); // Create user controller instance

            var user_temp = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // Create a new user
            this.userController.PostUser(user_temp).GetAwaiter().GetResult(); // Signup the user

            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "12345" }; // New user with incorrect password
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult(); // Attempt login
            Assert.IsNotNull(result); // Ensure result is not null
            Assert.IsInstanceOfType(result, typeof(BadRequestResult)); // Expect a Bad Request for incorrect password
        }

        // Method to setup the fake database context
        private void GivenUnishopDbContext()
        {
            var fakeSet = new FakeUserDbSet(); // Create a fake user DbSet
            fakeSet.AddRange(new[] { new user { }, new user { }, new user { } }); // Add some fake users
            var mock = new Mock<IUnishopEntities>(); // Create a mock for the database context
            mock.As<IDisposable>().Setup(x => x.Dispose()); // Setup disposal
            mock.Setup(x => x.users).Returns(fakeSet); // Return the fake user DbSet
            mock.Setup(x => x.SetModified(It.IsAny<object>())); // Setup modifying object

            this.unishopDbContext = mock.Object; // Assign the mock object to the database context
        }

        // Method to create the user controller instance
        private void GivenUserController()
        {
            this.userController = new UserController(this.unishopDbContext); // Create the UserController with the fake database context
        }
    }
}
```