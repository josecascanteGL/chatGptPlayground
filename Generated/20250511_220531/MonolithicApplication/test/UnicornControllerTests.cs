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
            this.GivenUnishopDbContext(); // Initialize the fake database context
            this.GivenUnicornController(); // Initialize the UnicornController
        }

        [TestMethod]
        public void GetUnicorns_WhenCalled_ReturnTwoUnicorns()
        {
            var unicorns = this.unicornController.GetUnicorns(); // Call the GetUnicorns method from UnicornController

            unicorns.Should().HaveCount(2, "because 2 unicorns are added to DbContext.Unicorns"); // Check if 2 unicorns are returned 
        }

        [TestMethod]
        public void GetUnicorns_WhenCalled_ReturnIQueriableOfUnicorn()
        {
            var unicorns = this.unicornController.GetUnicorns(); // Call the GetUnicorns method from UnicornController

            Assert.IsInstanceOfType(unicorns, typeof(IQueryable<inventory>)); // Check if the returned type is IQueryable of inventory
        }

        [TestMethod]
        public async Task GetUnicorn_ExistingUnicornId_ReturnOkResult()
        {
            var guid = Guid.NewGuid();
            this.unishopDbContext.inventories.Add(new inventory { unicorn_id = guid }); // Add a unicorn with the generated Guid to the fake DbSet

            var actionResult = await this.unicornController.GetUnicorn(guid); // Call the GetUnicorn method with the generated Guid
            var contentResult = actionResult as OkNegotiatedContentResult<inventory>; // Check if the result is Ok with content

            Assert.IsNotNull(contentResult); // Check if the contentResult is not null
            Assert.IsNotNull(contentResult.Content); // Check if the content inside the result is not null
            Assert.AreEqual(guid, contentResult.Content.unicorn_id); // Check if the returned unicorn id matches the generated Guid
        }

        [TestMethod]
        public async Task GetUnicorn_NonExistingUnicornId_ReturnNotFoundResult()
        {
            var guid = Guid.NewGuid();

            var actionResult = await this.unicornController.GetUnicorn(guid); // Call the GetUnicorn method with a non-existing Guid

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult)); // Check if the result is NotFound
        }

        // it seems there is no validation for the unicorn model
        [TestMethod]
        public async Task PutUnicorn_InvalidModel_ReturnInvalidModelState()
        {
            var guid = Guid.NewGuid();
            var unicorn = new inventory { unicorn_id = guid };
            this.unicornController.ModelState.AddModelError("fake model error", "fake model error"); // Add an error to the model state

            var actionResult = await this.unicornController.PutUnicorn(guid, unicorn); // Call the PutUnicorn method with the generated Guid and unicorn

            Assert.IsInstanceOfType(actionResult, typeof(InvalidModelStateResult)); // Check if the result is InvalidModelState
        }

        [TestMethod]
        public async Task PutUnicorn_DifferentId_ReturnBadRequest()
        {
            var guid = Guid.NewGuid();
            var unicornWithDiffId = new inventory { unicorn_id = Guid.NewGuid() }; // Create a unicorn with a different Guid

            var actionResult = await this.unicornController.PutUnicorn(guid, unicornWithDiffId); // Call the PutUnicorn method with the generated Guid and different unicorn

            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult)); // Check if the result is BadRequest
        }

        [TestMethod]
        public async Task PutUnicorn_AsyncSaveSucceed_ReturnNoContent()
        {
            var guid = Guid.NewGuid();
            var unicornWithSameId = new inventory { unicorn_id = guid };
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0)); // Set up the SaveChangesAsync method to return 0

            var actionResult = await this.unicornController.PutUnicorn(guid, unicornWithSameId); // Call the PutUnicorn method

            var statusCodeResult = actionResult as StatusCodeResult;

            Assert.IsNotNull(statusCodeResult); // Check if the result is not null
            Assert.AreEqual(HttpStatusCode.NoContent, statusCodeResult.StatusCode); // Check if the status code is NoContent
        }

        [TestMethod]
        public async Task PutUnicorn_AsyncSaveFailAndUnicornExists_ThrowException()
        {
            var guid = Guid.NewGuid();
            var unicornWithSameId = new inventory { unicorn_id = guid };
            this.unishopDbContext.inventories.Add(unicornWithSameId); // Add the unicorn to the context
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Throws(new DbUpdateConcurrencyException()); // Set up SaveChangesAsync to throw an exception

            await Assert.ThrowsExceptionAsync<DbUpdateConcurrencyException>(async () => { await this.unicornController.PutUnicorn(guid, unicornWithSameId); }); // Check if the expected exception is thrown
        }

        [TestMethod]
        public async Task PutUnicorn_AsyncSaveFailAndUnicornNotExists_ReturnNotFound()
        {
            var guid = Guid.NewGuid();
            var unicornWithSameId = new inventory { unicorn_id = guid };
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Throws(new DbUpdateConcurrencyException()); // Set up SaveChangesAsync to throw an exception

            var actionResult = await this.unicornController.PutUnicorn(guid, unicornWithSameId); // Call the PutUnicorn method

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult)); // Check if the result is NotFound
        }

        [TestMethod]
        public async Task PostUnicorn_InvalidModel_ReturnInvalidModelState()
        {
            var unicorn = new inventory { unicorn_id = Guid.NewGuid() };
            this.unicornController.ModelState.AddModelError("fake model error", "fake model error"); // Add an error to the model state

            var actionResult = await this.unicornController.PostUnicorn(unicorn); // Call the PostUnicorn method

            Assert.IsInstanceOfType(actionResult, typeof(InvalidModelStateResult)); // Check if the result is InvalidModelState
        }

        [TestMethod]
        public async Task PostUnicorn_WhenCalled_UnicornInList()
        {
            var guid = Guid.NewGuid();
            var unicorn = new inventory { unicorn_id = guid };
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0)); // Set up SaveChangesAsync to return 0

            var actionResult = await this.unicornController.PostUnicorn(unicorn); // Call the PostUnicorn method
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<inventory>;

            Assert.IsNotNull(createdResult); // Check if the result is not null
            Assert.AreEqual(unicorn.unicorn_id, createdResult.Content.unicorn_id); // Check if the returned unicorn id matches the generated Guid
        }

        [TestMethod]
        public async Task PostUnicorn_WhenCalled_ReDirectToDefaultAPI()
        {
            var guid = Guid.NewGuid();
            var unicorn = new inventory { unicorn_id = guid };

            var actionResult = await this.unicornController.PostUnicorn(unicorn); // Call the PostUnicorn method
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<inventory>;

            Assert.IsNotNull(createdResult); // Check if the result is not null
            Assert.AreEqual("DefaultApi", createdResult.RouteName); // Check if the route name is DefaultApi
            Assert.AreEqual(unicorn.unicorn_id, createdResult.RouteValues["id"]); // Check if the unicorn id in the route values matches the generated Guid
        }

        [TestMethod]
        public async Task DeleteUnicorn_UnicornNotFound_ReturnNotFound()
        {
            var guid = Guid.NewGuid();

            var actionResult = await this.unicornController.DeleteUnicorn(guid); // Call the DeleteUnicorn method

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult)); // Check if the result is NotFound
        }

        [TestMethod]
        public async Task DeleteUnicorn_UnicornFound_DeleteUnicornFromList()
        {
            var guid = Guid.NewGuid();
            var unicorn = new inventory { unicorn_id = guid };
            this.unishopDbContext.inventories.Add(unicorn); // Add the unicorn to the context
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0)); // Set up SaveChangesAsync to return 0

            await this.unicornController.DeleteUnicorn(guid); // Call the DeleteUnicorn method

            Assert.AreEqual(0, this.unishopDbContext.inventories.Count(e => e.unicorn_id == guid)); // Check if the unicorn is removed from the list
        }

        [TestMethod]
        public async Task DeleteUnicorn_UnicornFound_ReturnOk()
        {
            var guid = Guid.NewGuid();
            var unicorn = new inventory { unicorn_id = guid };
            this.unishopDbContext.inventories.Add(unicorn); // Add the unicorn to the context
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0)); // Set up SaveChangesAsync to return 0

            var actionResult = await this.unicornController.DeleteUnicorn(guid); // Call the DeleteUnicorn method
            var contentResult = actionResult as OkNegotiatedContentResult<inventory>;

            Assert.IsNotNull(contentResult); // Check if the result is not null
            Assert.IsNotNull(contentResult.Content); // Check if the content inside the result is not null
            Assert.AreEqual(guid, contentResult.Content.unicorn_id); // Check if the returned unicorn id matches the generated Guid
        }

        private void GivenUnishopDbContext()
        {
            var fakeSet = new FakeUnicornDbSet(); // Create a fake DbSet
            fakeSet.AddRange(new[] { new inventory { unicorn_id = Guid.NewGuid() }, new inventory { unicorn_id = Guid.NewGuid() } }); // Add some unicorns to the fake DbSet

            this.mockedUnicornEntities = new Mock<IUnishopEntities>(); // Create a mocked UnicornEntities
            this.mockedUnicornEntities.As<IDisposable>().Setup(x => x.Dispose()); // Setup disposal
            this.mockedUnicornEntities.Setup(x => x.inventories).Returns(fakeSet); // Set the inventories property to the fake DbSet
            this.mockedUnicornEntities.Setup(x => x.SetModified(It.IsAny<object>())); 

            this.unishopDbContext = this.mockedUnicornEntities.Object; // Assign the mock to the actual context
        }

        private void GivenUnicornController()
        {
            this.unicornController = new UnicornController(this.unishopDbContext); // Initialize the UnicornController with the fake context
        }
    }
}
