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
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnicornShopLegacy.Controllers;
using UnicornShopLegacy.Interfaces;

namespace UnicornShopLegacy.Tests
{
    [TestClass]
    public class UnicornControllerTests
    {
        private IUnishopEntities unishopDbContext;
        private UnicornController unicornController;
        private Mock<IUnishopEntities> mockedUnicornEntities;

        [TestInitialize]
        public void Init()
        {
            this.GivenUnishopDbContext();
            this.GivenUnicornController();
        }

        [TestMethod]
        public void GetUnicorns_WhenCalled_ReturnTwoUnicorns()
        {
            // Act
            var unicorns = this.unicornController.GetUnicorns();

            // Assert
            unicorns.Should().HaveCount(2, "because 2 unicorns are added to DbContext.Unicorns");
        }

        [TestMethod]
        public void GetUnicorns_WhenCalled_ReturnIQueriableOfUnicorn()
        {
            // Act
            var unicorns = this.unicornController.GetUnicorns();

            // Assert
            Assert.IsInstanceOfType(unicorns, typeof(IQueryable<inventory>));
        }

        [TestMethod]
        public async Task GetUnicorn_ExistingUnicornId_ReturnOkResult()
        {
            // Arrange
            var guid = Guid.NewGuid();
            this.unishopDbContext.inventories.Add(new inventory { unicorn_id = guid });

            // Act
            var actionResult = await this.unicornController.GetUnicorn(guid);
            var contentResult = actionResult as OkNegotiatedContentResult<inventory>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(guid, contentResult.Content.unicorn_id);
        }

        [TestMethod]
        public async Task GetUnicorn_NonExistingUnicornId_ReturnNotFoundResult()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act
            var actionResult = await this.unicornController.GetUnicorn(guid);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        // it seems there is no validation for the unicorn model
        [TestMethod]
        public async Task PutUnicorn_InvalidModel_ReturnInvalidModelState()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var unicorn = new inventory { unicorn_id = guid };
            this.unicornController.ModelState.AddModelError("fake model error", "fake model error");

            // Act
            var actionResult = await this.unicornController.PutUnicorn(guid, unicorn);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public async Task PutUnicorn_DifferentId_ReturnBadRequest()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var unicornWithDiffId = new inventory { unicorn_id = Guid.NewGuid() };

            // Act
            var actionResult = await this.unicornController.PutUnicorn(guid, unicornWithDiffId);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task PutUnicorn_AsyncSaveSucceed_ReturnNoContent()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var unicornWithSameId = new inventory { unicorn_id = guid };
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0));

            // Act
            var actionResult = await this.unicornController.PutUnicorn(guid, unicornWithSameId);
            var statusCodeResult = actionResult as StatusCodeResult;

            // Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(HttpStatusCode.NoContent, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public async Task PutUnicorn_AsyncSaveFailAndUnicornExists_ThrowException()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var unicornWithSameId = new inventory { unicorn_id = guid };
            this.unishopDbContext.inventories.Add(unicornWithSameId);
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Throws(new DbUpdateConcurrencyException());

            // Act & Assert
            await Assert.ThrowsExceptionAsync<DbUpdateConcurrencyException>(async () => { await this.unicornController.PutUnicorn(guid, unicornWithSameId);  });
        }

        [TestMethod]
        public async Task PutUnicorn_AsyncSaveFailAndUnicornNotExists_ReturnNotFound()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var unicornWithSameId = new inventory { unicorn_id = guid };
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Throws(new DbUpdateConcurrencyException());

            // Act
            var actionResult = await this.unicornController.PutUnicorn(guid, unicornWithSameId);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PostUnicorn_InvalidModel_ReturnInvalidModelState()
        {
            // Arrange
            var unicorn = new inventory { unicorn_id = Guid.NewGuid() };
            this.unicornController.ModelState.AddModelError("fake model error", "fake model error");

            // Act
            var actionResult = await this.unicornController.PostUnicorn(unicorn);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public async Task PostUnicorn_WhenCalled_UnicornInList()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var unicorn = new inventory { unicorn_id = guid };
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0));

            // Act
            var actionResult = await this.unicornController.PostUnicorn(unicorn);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<inventory>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(unicorn.unicorn_id, createdResult.Content.unicorn_id);
        }

        [TestMethod]
        public async Task PostUnicorn_WhenCalled_ReDirectToDefaultAPI()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var unicorn = new inventory { unicorn_id = guid };

            // Act
            var actionResult = await this.unicornController.PostUnicorn(unicorn);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<inventory>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(unicorn.unicorn_id, createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public async Task DeleteUnicorn_UnicornNotFound_ReturnNotFound()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act
            var actionResult = await this.unicornController.DeleteUnicorn(guid);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task DeleteUnicorn_UnicornFound_DeleteUnicornFromList()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var unicorn = new inventory { unicorn_id = guid };
            this.unishopDbContext.inventories.Add(unicorn);
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0));

            // Act
            await this.unicornController.DeleteUnicorn(guid);

            // Assert
            Assert.AreEqual(0, this.unishopDbContext.inventories.Count(e => e.unicorn_id == guid));
        }

        [TestMethod]
        public async Task DeleteUnicorn_UnicornFound_ReturnOk()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var unicorn = new inventory { unicorn_id = guid };
            this.unishopDbContext.inventories.Add(unicorn);
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0));

            // Act
            var actionResult = await this.unicornController.DeleteUnicorn(guid);
            var contentResult = actionResult as OkNegotiatedContentResult<inventory>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(guid, contentResult.Content.unicorn_id);
        }

        private void GivenUnishopDbContext()
        {
            var fakeSet = new FakeUnicornDbSet();
            fakeSet.AddRange(new[] { new inventory { unicorn_id = Guid.NewGuid() }, new inventory { unicorn_id = Guid.NewGuid() } });

            this.mockedUnicornEntities = new Mock<IUnishopEntities>();
            this.mockedUnicornEntities.As<IDisposable>().Setup(x => x.Dispose());
            this.mockedUnicornEntities.Setup(x => x.inventories).Returns(fakeSet);
            this.mockedUnicornEntities.Setup(x => x.SetModified(It.IsAny<object>()));

            this.unishopDbContext = this.mockedUnicornEntities.Object;
        }

        private void GivenUnicornController()
        {
            this.unicornController = new UnicornController(this.unishopDbContext);
        }
    }
}
