using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Protocol;
using SpartaToDo.App.Controllers;
using SpartaToDo.App.Data;
using SpartaToDo.App.Models.ViewModels;
using SpartaToDo.App.Services;

namespace SpartaToDo.Tests
{
    public class Tests
    {

        private ToDoItemsController _sut;
        [Test]
        public void BeAbleToBeConstructed()
        {
            var mockService = new Mock<IToDoService>();
            _sut = new ToDoItemsController(It.IsAny<SpartaToDoContext>(), It.IsAny<IMapper>(), mockService.Object);
            Assert.That(_sut, Is.InstanceOf<ToDoItemsController>());
        }

        [Test]
        public void Index_WithSucessfulSerivceResponse_ReturnsTodoVM()
        {
            var mockService = new Mock<IToDoService>();
            mockService.Setup(ms => ms.GetToDoItemsAsync(It.IsAny<string>()).Result).Returns(Helper.GetToDoListServiceResponse());
            _sut = new ToDoItemsController(It.IsAny<SpartaToDoContext>(), It.IsAny<IMapper>(), mockService.Object);
            var result = _sut.Index(It.IsAny<string>()).Result;

            Assert.That(result, Is.InstanceOf<ViewResult>());

            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.InstanceOf<IEnumerable<ToDoVM>>());
        }

        public void Index_WithUnsucessfulSerivceResponse_ReturnsProblem()
        {
            var mockService = new Mock<IToDoService>();
            var response = Helper.GetFailedServiceResponse<IEnumerable<ToDoVM>>("Fake problem");



            mockService.Setup(ms => ms.GetToDoItemsAsync(It.IsAny<string>()).Result).Returns(response);

            _sut = new ToDoItemsController(It.IsAny<SpartaToDoContext>(), It.IsAny<IMapper>(), mockService.Object);

            var result = _sut.Index(It.IsAny<string>()).Result;

            Assert.That(result, Is.InstanceOf<ObjectResult>());

            var objectResult = result as ObjectResult;
            Assert.That(objectResult.ToJson(), Does.Contain("Fake Problem"));
            Assert.That((int)objectResult.StatusCode, Is.EqualTo(500));
        }
    }
}