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
            // Initialize the test environment
            this.GivenUnishopDbContext();
            this.GivenUserController();

            // Retrieve users using the UserController
            var users = this.userController.GetUsers();
            Assert.IsNotNull(users);
            Assert.AreEqual(users.Count(), 3);
        }

        [TestMethod]
        public void SignUPTestSuccess()
        {
            // Initialize the test environment
            this.GivenUnishopDbContext();
            this.GivenUserController();

            // Create a new user
            var user = new user { user_id = Guid.NewGuid(), email = "456@gmail.com", password = "123456" };
            // Call the PostUser method of UserController
            var result = this.userController.PostUser(user).GetAwaiter().GetResult();
            Assert.IsNotNull(result);

            // Check the result of user creation
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<user>));
            var confirmed_result = result as CreatedAtRouteNegotiatedContentResult<user>;
            Assert.AreEqual(confirmed_result.RouteName, "DefaultApi");
            Assert.AreEqual(confirmed_result.RouteValues["id"], confirmed_result.Content.user_id);
            Assert.AreEqual(confirmed_result.Content.user_id, user.user_id);

            // Cleanup - Remove the user
            // this.unishopDbContext.user.Remove(confirmed_result.Content);
        }

        [TestMethod]
        public void SignUpTestDuplicateEmail_ShouldFail()
        {
            // Initialize the test environment
            this.GivenUnishopDbContext();
            this.GivenUserController();

            // Create a new user with a duplicate email
            var user = new user { user_id = Guid.NewGuid(), email = "qwertyuio@gmail.com", password = "123456" };
            var result = this.userController.PostUser(user).GetAwaiter().GetResult();
            var confirmed_result = result as CreatedAtRouteNegotiatedContentResult<user>;

            // Try to create another user with the same email
            result = this.userController.PostUser(user).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void LoginTestSuccess()
        {
            // Initialize the test environment
            this.GivenUnishopDbContext();
            this.GivenUserController();

            // Create a user and login
            var user_temp = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" };
            this.userController.PostUser(user_temp).GetAwaiter().GetResult();

            // Attempt to login with the created user
            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" };
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult();
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<user>));
        }

        [TestMethod]
        public void LoginTestUserNotExist_ShouldFail()
        {
            // Initialize the test environment
            this.GivenUnishopDbContext();
            this.GivenUserController();

            // Attempt to login with a user that does not exist
            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" };
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void LoginTestPasswordIncorrect_ShouldFail()
        {
            // Initialize the test environment
            this.GivenUnishopDbContext();
            this.GivenUserController();

            // Create a user with a specific password and login with a different password
            var user_temp = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "123456" };
            this.userController.PostUser(user_temp).GetAwaiter().GetResult();

            var user_temp_new = new user { user_id = Guid.NewGuid(), email = "56@gmail.com", password = "12345" };
            var result = this.userController.PostLogin(user_temp_new).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        private void GivenUnishopDbContext()
        {
            // Set up a fake user database context
            var fakeSet = new FakeUserDbSet();
            fakeSet.AddRange(new[] { new user { }, new user { }, new user { } });
            var mock = new Mock<IUnishopEntities>();
            mock.As<IDisposable>().Setup(x => x.Dispose());
            mock.Setup(x => x.users).Returns(fakeSet);
            mock.Setup(x => x.SetModified(It.IsAny<object>()));

            this.unishopDbContext = mock.Object;
        }

        private void GivenUserController()
        {
            // Create a new instance of UserController with the fake database context
            this.userController = new UserController(this.unishopDbContext);
        }
    }
}