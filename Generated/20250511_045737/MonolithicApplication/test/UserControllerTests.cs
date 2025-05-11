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

        [TestMethod]
        public void GetUsersTest()
        {
            this.GivenUnishopDbContext(); // Initializing the test data
            this.GivenUserController(); // Initializing the UserController

            var users = this.userController.GetUsers(); // Calling the GetUsers method in UserController
            Assert.IsNotNull(users); // Verifying that the result is not null
            Assert.AreEqual(users.Count(), 3); // Verifying that the number of users fetched is 3
        }

        [TestMethod]
        public void SignUPTestSuccess()
        {
            this.GivenUnishopDbContext(); // Initializing the test data
            this.GivenUserController(); // Initializing the UserController

            var user = new user { user_id = Guid.NewGuid(), email = "456@gmail.com", password = "123456" }; // Creating a new user object
            var result = this.userController.PostUser(user).GetAwaiter().GetResult(); // Calling the PostUser method in UserController
            Assert.IsNotNull(result); // Verifying that the result is not null

            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<user>)); // Verifying the type of result
            var confirmed_result = result as CreatedAtRouteNegotiatedContentResult<user>; // Casting the result to CreatedAtRouteNegotiatedContentResult
            Assert.AreEqual(confirmed_result.RouteName, "DefaultApi"); // Verifying the RouteName
            Assert.AreEqual(confirmed_result.RouteValues["id"], confirmed_result.Content.user_id); // Verifying the RouteValues
            Assert.AreEqual(confirmed_result.Content.user_id, user.user_id); // Verifying the user_id

            // this.unishopDbContext.user.Remove(confirmed_result.Content); // Uncomment this line to remove the user after the test
        }

        [TestMethod]
        public void SignUpTestDuplicateEmail_ShouldFail()
        {
            this.GivenUnishopDbContext(); // Initializing the test data
            this.GivenUserController(); // Initializing the UserController

            var user = new user { user_id = Guid.NewGuid(), email = "qwertyuio@gmail.com", password = "123456" }; // Creating a new user object
            var result = this.userController.PostUser(user).GetAwaiter().GetResult(); // Calling the PostUser method in UserController
            var confirmed_result = result as CreatedAtRouteNegotiatedContentResult<user>; // Casting the result to CreatedAtRouteNegotiatedContentResult

            result = this.userController.PostUser(user).GetAwaiter().GetResult(); // Calling the PostUser method again with the same user
            Assert.IsNotNull(result); // Verifying that the result is not null
            Assert.IsInstanceOfType(result, typeof(BadRequestResult)); // Verifying that the result is of BadRequest type
        }

        [TestMethod]
        public void LoginTestSuccess()
        {
            this.GivenUnishopDbContext(); // Initializing the test data
            this.GivenUserController(); // Initializing the UserController

            var user_temp = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // Creating a new user object
            this.userController.PostUser(user_temp).GetAwaiter().GetResult(); // Adding the user to the database

            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // Creating another new user object
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult(); // Calling the PostLogin method in UserController
            Assert.IsNotNull(result); // Verifying that the result is not null

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<user>)); // Verifying that the result is of OkNegotiatedContent type
        }

        [TestMethod]
        public void LoginTestUserNotExist_ShouldFail()
        {
            this.GivenUnishopDbContext(); // Initializing the test data
            this.GivenUserController(); // Initializing the UserController

            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // Creating a new user object
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult(); // Calling the PostLogin method in UserController
            Assert.IsNotNull(result); // Verifying that the result is not null
            Assert.IsInstanceOfType(result, typeof(NotFoundResult)); // Verifying that the result is of NotFound type
        }

        [TestMethod]
        public void LoginTestPasswordIncorrect_ShouldFail()
        {
            this.GivenUnishopDbContext(); // Initializing the test data
            this.GivenUserController(); // Initializing the UserController

            var user_temp = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // Creating a new user object
            this.userController.PostUser(user_temp).GetAwaiter().GetResult(); // Adding the user to the database

            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "12345" }; // Creating another new user object with incorrect password
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult(); // Calling the PostLogin method in UserController
            Assert.IsNotNull(result); // Verifying that the result is not null
            Assert.IsInstanceOfType(result, typeof(BadRequestResult)); // Verifying that the result is of BadRequest type
        }

        private void GivenUnishopDbContext()
        {
            var fakeSet = new FakeUserDbSet(); // Creating a fake DbSet for user objects
            fakeSet.AddRange(new[] { new user { }, new user { }, new user { } }); // Adding sample user objects to the fake DbSet
            var mock = new Mock<IUnishopEntities>(); // Creating a mock for IUnishopEntities
            mock.As<IDisposable>().Setup(x => x.Dispose()); // Setting up IDisposable in the mock
            mock.Setup(x => x.users).Returns(fakeSet); // Setting up the users property in the mock to return the fake DbSet
            mock.Setup(x => x.SetModified(It.IsAny<object>())); // Setting up the SetModified method in the mock

            this.unishopDbContext = mock.Object; // Initializing the unishopDbContext with the mock object
        }

        private void GivenUserController()
        {
            this.userController = new UserController(this.unishopDbContext); // Initializing the userController with the unishopDbContext
        }
    }
}
```