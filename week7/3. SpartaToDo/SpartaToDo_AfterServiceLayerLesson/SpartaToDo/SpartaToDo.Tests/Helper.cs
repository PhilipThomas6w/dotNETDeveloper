using Moq;
using SpartaToDo.App.Models.ViewModels;
using SpartaToDo.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaToDo.Tests
{
    public  static class Helper
    {
        public static ServiceResponse<T> GetFailedServiceResponse<T>(string message = "")
        {
            var response = new ServiceResponse<T>();
            response.Success = false;
            response.Message = message;
            return response;
        }

        public static ServiceResponse<IEnumerable<ToDoVM>> GetToDoListServiceResponse()
        {
            var response = new ServiceResponse<IEnumerable<ToDoVM>>();
            response.Data = new List<ToDoVM>
            {
                Mock.Of<ToDoVM>(),
                Mock.Of<ToDoVM>()
            };
            return response;
        }

        public static ServiceResponse<ToDoVM> GetToDoItemServiceResponse()
        {
            var response = new ServiceResponse<ToDoVM>();
            response.Data = Mock.Of<ToDoVM>();
            return response;
        }
    }
}
