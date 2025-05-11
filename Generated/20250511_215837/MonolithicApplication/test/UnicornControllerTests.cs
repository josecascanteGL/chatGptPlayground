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
        private IUnishopEntities unishopDbContext; // Declare an interface for accessing the application data.
        private UnicornController unicornController; // Declare the UnicornController instance for testing.
        private Mock<IUnishopEntities> mockedUnicornEntities; // Mock object for the Unicorn entities.

        [TestInitialize]
        public void Init() // Method to initialize the test setup.
        {
            this.GivenUnishopDbContext(); // Call the method to set up the application data context.
            this.GivenUnicornController(); // Call the method to set up the UnicornController instance.
        }

        [TestMethod]
        public void GetUnicorns_WhenCalled_ReturnTwoUnicorns() // Test method for getting unicorns count.
        {
            var unicorns = this.unicornController.GetUnicorns(); // Get the unicorns from the controller.

            unicorns.Should().HaveCount(2, "because 2 unicorns are added to DbContext.Unicorns"); // Check that there are 2 unicorns in the result.
        }

        [TestMethod]
        public void GetUnicorns_WhenCalled_ReturnIQueriableOfUnicorn() // Test method for checking unicorn query type.
        {
            var unicorns = this.unicornController.GetUnicorns(); // Get the unicorns from the controller.

            Assert.IsInstanceOfType(unicorns, typeof(IQueryable<inventory>)); // Check if the result is of type IQueryable<inventory>.
        }

        [TestMethod]
        public async Task GetUnicorn_ExistingUnicornId_ReturnOkResult() // Test method for getting an existing unicorn by ID.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.
            this.unishopDbContext.inventories.Add(new inventory { unicorn_id = guid }); // Add a unicorn with the generated GUID.

            var actionResult = await this.unicornController.GetUnicorn(guid); // Get the unicorn by ID.
            var contentResult = actionResult as OkNegotiatedContentResult<inventory>; // Check if the result is OkNegotiatedContentResult.

            Assert.IsNotNull(contentResult); // Ensure the content result is not null.
            Assert.IsNotNull(contentResult.Content); // Ensure the content within the result is not null.
            Assert.AreEqual(guid, contentResult.Content.unicorn_id); // Check if the returned unicorn ID matches the requested one.
        }

        [TestMethod]
        public async Task GetUnicorn_NonExistingUnicornId_ReturnNotFoundResult() // Test method for getting a non-existing unicorn by ID.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.

            var actionResult = await this.unicornController.GetUnicorn(guid); // Get the unicorn by ID.

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult)); // Check if the result is a NotFoundResult.
        }

        // it seems there is no validation for the unicorn model
        [TestMethod]
        public async Task PutUnicorn_InvalidModel_ReturnInvalidModelState() // Test method for putting an invalid unicorn model.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.
            var unicorn = new inventory { unicorn_id = guid }; // Create a unicorn instance.
            this.unicornController.ModelState.AddModelError("fake model error", "fake model error"); // Add a model error.

            var actionResult = await this.unicornController.PutUnicorn(guid, unicorn); // Put the unicorn with the specified ID.

            Assert.IsInstanceOfType(actionResult, typeof(InvalidModelStateResult)); // Check if the result is an InvalidModelStateResult.
        }

        [TestMethod]
        public async Task PutUnicorn_DifferentId_ReturnBadRequest() // Test method for putting a unicorn with a different ID.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.
            var unicornWithDiffId = new inventory { unicorn_id = Guid.NewGuid() }; // Create a unicorn with a different ID.

            var actionResult = await this.unicornController.PutUnicorn(guid, unicornWithDiffId); // Put the unicorn with a different ID.

            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult)); // Check if the result is a BadRequestResult.
        }

        [TestMethod]
        public async Task PutUnicorn_AsyncSaveSucceed_ReturnNoContent() // Test method for successfully saving a unicorn.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.
            var unicornWithSameId = new inventory { unicorn_id = guid }; // Create a unicorn with the same ID.
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0)); // Set up the mock to return a task.

            var actionResult = await this.unicornController.PutUnicorn(guid, unicornWithSameId); // Put the unicorn in an async operation.
            var statusCodeResult = actionResult as StatusCodeResult; // Check if the result is a StatusCodeResult.

            Assert.IsNotNull(statusCodeResult); // Ensure the status code result is not null.
            Assert.AreEqual(HttpStatusCode.NoContent, statusCodeResult.StatusCode); // Check if the status code is NoContent.
        }

        [TestMethod]
        public async Task PutUnicorn_AsyncSaveFailAndUnicornExists_ThrowException() // Test method for handling async save failure when unicorn exists.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.
            var unicornWithSameId = new inventory { unicorn_id = guid }; // Create a unicorn with the same ID.
            this.unishopDbContext.inventories.Add(unicornWithSameId); // Add the unicorn to the list.
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Throws(new DbUpdateConcurrencyException()); // Set up the mock to throw an exception.

            await Assert.ThrowsExceptionAsync<DbUpdateConcurrencyException>(async () => { await this.unicornController.PutUnicorn(guid, unicornWithSameId); }); // Assert that the specified exception is thrown.
        }

        [TestMethod]
        public async Task PutUnicorn_AsyncSaveFailAndUnicornNotExists_ReturnNotFound() // Test method for handling async save failure when unicorn does not exist.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.
            var unicornWithSameId = new inventory { unicorn_id = guid }; // Create a unicorn with the same ID.
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Throws(new DbUpdateConcurrencyException()); // Set up the mock to throw an exception.

            var actionResult = await this.unicornController.PutUnicorn(guid, unicornWithSameId); // Put the unicorn and handle the exception.

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult)); // Check if the result is a NotFoundResult.
        }

        [TestMethod]
        public async Task PostUnicorn_InvalidModel_ReturnInvalidModelState() // Test method for posting an invalid unicorn model.
        {
            var unicorn = new inventory { unicorn_id = Guid.NewGuid() }; // Create a new unicorn instance.
            this.unicornController.ModelState.AddModelError("fake model error", "fake model error"); // Add a model error.

            var actionResult = await this.unicornController.PostUnicorn(unicorn); // Post the unicorn with model validation.

            Assert.IsInstanceOfType(actionResult, typeof(InvalidModelStateResult)); // Check if the result is an InvalidModelStateResult.
        }

        [TestMethod]
        public async Task PostUnicorn_WhenCalled_UnicornInList() // Test method to verify unicorn addition to the list.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.
            var unicorn = new inventory { unicorn_id = guid }; // Create a unicorn instance.
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0)); // Set up the mock to return a task.

            var actionResult = await this.unicornController.PostUnicorn(unicorn); // Post the unicorn to the list.
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<inventory>; // Check if the result is CreatedAtRouteNegotiatedContentResult.

            Assert.IsNotNull(createdResult); // Ensure the created result is not null.
            Assert.AreEqual(unicorn.unicorn_id, createdResult.Content.unicorn_id); // Check if the created unicorn ID matches the original.
        }

        [TestMethod]
        public async Task PostUnicorn_WhenCalled_ReDirectToDefaultAPI() // Test method for redirecting to the default API after posting a unicorn.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.
            var unicorn = new inventory { unicorn_id = guid }; // Create a unicorn instance.

            var actionResult = await this.unicornController.PostUnicorn(unicorn); // Post the unicorn and redirect to the default API.
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<inventory>; // Check if the result is CreatedAtRouteNegotiatedContentResult.

            Assert.IsNotNull(createdResult); // Ensure the created result is not null.
            Assert.AreEqual("DefaultApi", createdResult.RouteName); // Check if the route name is "DefaultApi".
            Assert.AreEqual(unicorn.unicorn_id, createdResult.RouteValues["id"]); // Check if the unicorn ID matches the route values.
        }

        [TestMethod]
        public async Task DeleteUnicorn_UnicornNotFound_ReturnNotFound() // Test method for deleting a non-existing unicorn.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.

            var actionResult = await this.unicornController.DeleteUnicorn(guid); // Delete the unicorn by ID.

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult)); // Check if the result is a NotFoundResult.
        }

        [TestMethod]
        public async Task DeleteUnicorn_UnicornFound_DeleteUnicornFromList() // Test method for deleting an existing unicorn.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.
            var unicorn = new inventory { unicorn_id = guid }; // Create a unicorn instance.
            this.unishopDbContext.inventories.Add(unicorn); // Add the unicorn to the list.
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0)); // Set up the mock to return a task.

            await this.unicornController.DeleteUnicorn(guid); // Delete the unicorn by ID.

            Assert.AreEqual(0, this.unishopDbContext.inventories.Count(e => e.unicorn_id == guid)); // Check that the unicorn is deleted from the list.
        }

        [TestMethod]
        public async Task DeleteUnicorn_UnicornFound_ReturnOk() // Test method for successfully deleting a unicorn.
        {
            var guid = Guid.NewGuid(); // Generate a new GUID.
            var unicorn = new inventory { unicorn_id = guid }; // Create a unicorn instance.
            this.unishopDbContext.inventories.Add(unicorn); // Add the unicorn to the list.
            this.mockedUnicornEntities.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(0)); // Set up the mock to return a task.

            var actionResult = await this.unicornController.DeleteUnicorn(guid); // Delete the unicorn by ID.
            var contentResult = actionResult as OkNegotiatedContentResult<inventory>; // Check if the result is OkNegotiatedContentResult.

            Assert.IsNotNull(contentResult); // Ensure the content result is not null.
            Assert.IsNotNull(contentResult.Content); // Ensure the content within the result is not null.
            Assert.AreEqual(guid, contentResult.Content.unicorn_id); // Check if the returned unicorn ID matches the deleted one.
        }

        private void GivenUnishopDbContext() // Method to set up the application data context.
        {
            var fakeSet = new FakeUnicornDbSet(); // Create a fake Unicorn DbSet.
            fakeSet.AddRange(new[] { new inventory { unicorn_id = Guid.NewGuid() }, new inventory { unicorn_id = Guid.NewGuid() } }); // Add sample unicorns to the fake set.

            this.mockedUnicornEntities = new Mock<IUnishopEntities>(); // Initialize the mock for Unicorn entities.
            this.mockedUnicornEntities.As<IDisposable>().Setup(x => x.Dispose()); // Set up the mock to dispose when called.
            this.mockedUnicornEntities.Setup(x => x.inventories).Returns(fakeSet); // Set up the mock to return the fake unicorn set.
            this.mockedUnicornEntities.Setup(x => x.SetModified(It.IsAny<object>())); // Set up the mock for modification.

            this.unishopDbContext = this.mockedUnicornEntities.Object; // Assign the mock object to the actual context.
        }

        private void GivenUnicornController() // Method to set up the UnicornController instance.
        {
            this.unicornController = new UnicornController(this.unishopDbContext); // Initialize the UnicornController with the context.
        }
    }
}
