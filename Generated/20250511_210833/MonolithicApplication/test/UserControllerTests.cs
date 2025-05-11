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
            this.GivenUnishopDbContext(); // Initializing the fake database context
            this.GivenUserController(); // Initializing the user controller

            var users = this.userController.GetUsers(); // Getting the users from the controller
            Assert.IsNotNull(users); // Checking if the users are not null
            Assert.AreEqual(users.Count(), 3); // Checking if the number of users is 3
        }

        [TestMethod]
        public void SignUPTestSuccess()
        {
            this.GivenUnishopDbContext(); // Initializing the fake database context
            this.GivenUserController(); // Initializing the user controller

            var user = new user { user_id = Guid.NewGuid(), email = "456@gmail.com", password = "123456" }; // Creating a new user object
            var result = this.userController.PostUser(user).GetAwaiter().GetResult(); // Posting the user to the controller
            Assert.IsNotNull(result); // Checking if the result is not null

            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<user>)); // Checking the result type
            var confirmed_result = result as CreatedAtRouteNegotiatedContentResult<user>; // Casting the result to CreatedAtRouteNegotiatedContentResult with user type
            Assert.AreEqual(confirmed_result.RouteName, "DefaultApi"); // Checking the route name
            Assert.AreEqual(confirmed_result.RouteValues["id"], confirmed_result.Content.user_id); // Checking the route values
            Assert.AreEqual(confirmed_result.Content.user_id, user.user_id); // Checking the user id

            // this.unishopDbContext.user.Remove(confirmed_result.Content);
        }

        [TestMethod]
        public void SignUpTestDuplicateEmail_ShouldFail()
        {
            this.GivenUnishopDbContext(); // Initializing the fake database context
            this.GivenUserController(); // Initializing the user controller

            var user = new user { user_id = Guid.NewGuid(), email = "qwertyuio@gmail.com", password = "123456" }; // Creating a new user object
            var result = this.userController.PostUser(user).GetAwaiter().GetResult(); // Posting the user to the controller
            var confirmed_result = result as CreatedAtRouteNegotiatedContentResult<user>; // Casting the result to CreatedAtRouteNegotiatedContentResult with user type

            result = this.userController.PostUser(user).GetAwaiter().GetResult(); // Posting the user again
            Assert.IsNotNull(result); // Checking if the result is not null
            Assert.IsInstanceOfType(result, typeof(BadRequestResult)); // Checking the result type
        }

        [TestMethod]
        public void LoginTestSuccess()
        {
            this.GivenUnishopDbContext(); // Initializing the fake database context
            this.GivenUserController(); // Initializing the user controller

            var user_temp = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // Creating a new user object
            this.userController.PostUser(user_temp).GetAwaiter().GetResult(); // Posting the user

            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // Creating a new user object
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult(); // Posting the login request
            Assert.IsNotNull(result); // Checking if the result is not null

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<user>)); // Checking the result type
        }

        [TestMethod]
        public void LoginTestUserNotExist_ShouldFail()
        {
            this.GivenUnishopDbContext(); // Initializing the fake database context
            this.GivenUserController(); // Initializing the user controller

            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // Creating a new user object
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult(); // Posting the login request
            Assert.IsNotNull(result); // Checking if the result is not null
            Assert.IsInstanceOfType(result, typeof(NotFoundResult)); // Checking the result type
        }

        [TestMethod]
        public void LoginTestPasswordIncorrect_ShouldFail()
        {
            this.GivenUnishopDbContext(); // Initializing the fake database context
            this.GivenUserController(); // Initializing the user controller

            var user_temp = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" }; // Creating a new user object
            this.userController.PostUser(user_temp).GetAwaiter().GetResult(); // Posting the user

            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "12345" }; // Creating a new user object
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult(); // Posting the login request
            Assert.IsNotNull(result); // Checking if the result is not null
            Assert.IsInstanceOfType(result, typeof(BadRequestResult)); // Checking the result type
        }

        private void GivenUnishopDbContext()
        {
            var fakeSet = new FakeUserDbSet(); // Creating a fake database set
            fakeSet.AddRange(new[] { new user { }, new user { }, new user { } }); // Adding fake users to the database set
            var mock = new Mock<IUnishopEntities>(); // Creating a mock of the database context
            mock.As<IDisposable>().Setup(x => x.Dispose()); // Setting up Dispose method
            mock.Setup(x => x.users).Returns(fakeSet); // Setting up the users property to return the fake set
            mock.Setup(x => x.SetModified(It.IsAny<object>())); // Setting up SetModified method

            this.unishopDbContext = mock.Object; // Assigning the mocked database context to the instance variable
        }

        private void GivenUserController()
        {
            this.userController = new UserController(this.unishopDbContext); // Creating a new instance of UserController with the fake database context
        }
    }
}