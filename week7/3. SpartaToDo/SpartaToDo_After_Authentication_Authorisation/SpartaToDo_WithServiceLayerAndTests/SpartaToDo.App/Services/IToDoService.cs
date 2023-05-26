using SpartaToDo.App.Models;
using SpartaToDo.App.Models.ViewModels;

namespace SpartaToDo.App.Services
{
    public interface IToDoService
    {
        Task<ServiceResponse<IEnumerable<ToDoVM>>> GetToDoItemsAsync(Spartan spartan, string? filter = null);
        Task<ServiceResponse<ToDoVM>> GetDetailsAsync(int? id);
        Task<ServiceResponse<ToDoVM>> CreateToDoAsync(CreateToDoVM createTodoVM);
        Task<ServiceResponse<ToDoVM>> EditToDoAsync(int? id, ToDoVM todoVM);
        Task<ServiceResponse<ToDoVM>> UpdateToDoCompleteAsync(int id, MarkCompleteVM markCompleteVM);
        Task<ServiceResponse<ToDoVM>> DeleteToDoAsync(int? id);
        bool ToDoExists(int id);

        Task<string> GetSpartanOwnerAsync(int? id);  // From this, we are able to work out which ToDo item is related to which Spartan

        Task<ServiceResponse<Spartan>> GetUserAsync(HttpContext httpContext);
    }
}
