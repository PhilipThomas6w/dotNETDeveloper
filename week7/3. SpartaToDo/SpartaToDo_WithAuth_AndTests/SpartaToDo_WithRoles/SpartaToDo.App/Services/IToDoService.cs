using SpartaToDo.App.Models;
using SpartaToDo.App.Models.ViewModels;

namespace SpartaToDo.App.Services
{
    public interface IToDoService
    {
        Task<ServiceResponse<IEnumerable<ToDoVM>>> GetToDoItemsAsync(Spartan? spartan, string? filter = null, string role = "Trainee");
        Task<ServiceResponse<ToDoVM>> GetDetailsAsync(Spartan? spartan, int? id, string role);
        Task<ServiceResponse<ToDoVM>> CreateToDoAsync(Spartan? spartan, CreateToDoVM createTodoVM);
        Task<ServiceResponse<ToDoVM>> EditToDoAsync(Spartan? spartan, int? id, ToDoVM todoVM);
        Task<ServiceResponse<ToDoVM>> UpdateToDoCompleteAsync(Spartan? spartan, int id, MarkCompleteVM markCompleteVM);
        Task<ServiceResponse<ToDoVM>> DeleteToDoAsync(Spartan? spartan, int? id);
        Task<ServiceResponse<Spartan>> GetUserAsync(HttpContext httpContext);
        Task<string> GetSpartanOwnerAsync(int? id);
        bool ToDoExists(int id);
        string GetRole(HttpContext httpContext);
    }
}
