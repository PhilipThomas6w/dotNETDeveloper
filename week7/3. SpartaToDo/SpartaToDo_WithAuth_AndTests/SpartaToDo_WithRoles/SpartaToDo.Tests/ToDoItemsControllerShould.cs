using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Protocol;
using SpartaToDo.App.Controllers;
using SpartaToDo.App.Data;
using SpartaToDo.App.Models;
using SpartaToDo.App.Models.ViewModels;
using SpartaToDo.App.Services;

namespace SpartaToDo.Tests
{
    public class ToDoItemsControllerShould
    {
        private ToDoItemsController? _sut;
        [Test]
        public void BeAbleTobeConstructed()
        {
            var mockService = new Mock<IToDoService>();
            _sut = new ToDoItemsController(mockService.Object);
            Assert.That(_sut, Is.InstanceOf<ToDoItemsController>());
        }
        [Test]
        public void Index_WithSuccessfulServiceResponse_ReturnsTodoVMList()
        {
            // Arrange
            var mockService = new Mock<IToDoService>();
            var spartanServiceResponse = Helper.GetSpartanServiceResponse();

            mockService.Setup(s => s.GetUserAsync(It.IsAny<HttpContext>()).Result)
                       .Returns(spartanServiceResponse);
            mockService.Setup(s => s.GetToDoItemsAsync(spartanServiceResponse.Data, It.IsAny<string>(), It.IsAny<string>()))
                        .ReturnsAsync(Helper.GetToDoListServiceResponse());
            mockService.Setup(s => s.GetRole(It.IsAny<HttpContext>()))
                        .Returns("Trainer");

            _sut = new ToDoItemsController(mockService.Object);

            // Act
            var result = _sut.Index(null).Result;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());

            var viewResult = result as ViewResult;
            var data = viewResult!.Model;
            Assert.That(data, Is.InstanceOf<IEnumerable<ToDoVM>>());
        }


        [Test]
        public void Index_WithUnuccessfulServiceResponse_ReturnsProblem()
        {
            // Arrange
            var mockService = new Mock<IToDoService>();
            var spartanServiceResponse = Helper.GetSpartanServiceResponse();

            var failedResponse = Helper.GetFailedServiceResponse<IEnumerable<ToDoVM>>("Fake problem message");

            mockService.Setup(s => s.GetToDoItemsAsync(It.IsAny<Spartan>(), It.IsAny<string>(), It.IsAny<string>()).Result)
                       .Returns(failedResponse);
            mockService.Setup(s => s.GetUserAsync(It.IsAny<HttpContext>()).Result)
                        .Returns(spartanServiceResponse);

            _sut = new ToDoItemsController(mockService.Object);

            // Act
            var result = _sut.Index(null).Result;

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());

            var objectResult = result as ObjectResult;


            Assert.That(result.ToJson(), Does.Contain("Fake problem"));
            Assert.That((int)objectResult!.StatusCode, Is.EqualTo(500));
        }


        [Test]
        public void Edit_WithSuccessfulServiceResponse_ReturnsRedcirectToAction()
        {
            // Arrange
            var mockService = new Mock<IToDoService>();
            var spartanServiceResponse = Helper.GetSpartanServiceResponse();

            var response = Helper.GetToDoItemServiceResponse();

            mockService.Setup(s => s.EditToDoAsync(It.IsAny<Spartan>(), It.IsAny<int>(), It.IsAny<ToDoVM>()).Result)
                       .Returns(response);
            mockService.Setup(s => s.GetUserAsync(It.IsAny<HttpContext>()).Result)
                        .Returns(spartanServiceResponse);
            _sut = new ToDoItemsController(mockService.Object);

            // Act
            var result = _sut.Edit(It.IsAny<int>(), It.IsAny<ToDoVM>()).Result;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());

            var objectResult = result as RedirectToActionResult;


            var redirectToActionResult = result as RedirectToActionResult;
            Assert.That(redirectToActionResult!.ActionName, Is.EqualTo("Index"));

        }

        [Test]
        public void Edit_WithUnsuccessfulServiceResponse_ReturnsRedcirectToAction()
        {
            // Arrange
            var mockService = new Mock<IToDoService>();
            var failedResponse = Helper.GetFailedServiceResponse<ToDoVM>();
            var spartanServiceResponse = Helper.GetSpartanServiceResponse();
            failedResponse.Message = "Sad";
            mockService.Setup(s => s.GetUserAsync(It.IsAny<HttpContext>()).Result)
                    .Returns(spartanServiceResponse);
            mockService.Setup(s => s.EditToDoAsync(It.IsAny<Spartan>(), It.IsAny<int>(), It.IsAny<ToDoVM>()).Result)
                       .Returns(failedResponse);

            _sut = new ToDoItemsController(mockService.Object);

            // Act
            var result = _sut.Edit(It.IsAny<int>(), It.IsAny<ToDoVM>()).Result;

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());


            var objectResult = result as ObjectResult;
            Assert.That(objectResult.ToJson(), Does.Contain("Sad"));
            Assert.That((int)objectResult!.StatusCode, Is.EqualTo(500));
        }

    }
}