using SpartaToDo.App.Models;
using SpartaToDo.App.Models.ViewModels;

namespace SpartaToDo.App.Services
{
    public interface IToDoService
    {
        Task <ServiceResponse<IEnumerable<ToDoVM>>> GetToDoItemsAsync(string? filter = null);
        Task<ToDoVM> CreateToDoAsync(CreateToDoVM createTodoVM);
        Task<ToDoVM> GetDetailsAsync(int? id); 
        Task<ServiceResponse<ToDoVM>> EditToDoAsync(int? id, ToDoVM todoVM);
        Task<ToDoVM> UpdateToDoCompleteAsync(int id, MarkCompleteVM markCompleteVM);
        Task<ToDoVM> DeleteToDoAsync(int? id);
        bool ToDoExists(int id);
    }
}
