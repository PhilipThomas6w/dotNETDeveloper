using AutoMapper;
using SpartaToDo.App.Models;
using SpartaToDo.App.Models.ViewModels;

namespace SpartaToDo.App
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Create a mapping between CreateToDoVM and ToDO classes
            CreateMap<CreateToDoVM, ToDo>();
            // Create a mapping between ToDo and ToDoVM classes
            CreateMap<ToDo,ToDoVM>();
            //Create a mapping between ToDoVm and ToDo classes
            CreateMap<ToDoVM, ToDo>();
        }
    }
}
