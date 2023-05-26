using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpartaToDo.App.Data;
using SpartaToDo.App.Models;
using SpartaToDo.App.Models.ViewModels;

namespace SpartaToDo.App.Services
{
    public class ToDoService : IToDoService
    {
        private readonly SpartaToDoContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Spartan> _userManager;
        public ToDoService(SpartaToDoContext context, IMapper mapper, UserManager<Spartan> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<ToDoVM>> CreateToDoAsync(Spartan? user, CreateToDoVM createTodoVM)
        {
            var response = new ServiceResponse<ToDoVM>();

            if (user == null)
            {
                response.Success = false;
                response.Message = "No user found";
                return response;
            }
            try
            {
                var toDo = _mapper.Map<ToDo>(createTodoVM);
                toDo.Spartan = user;
                _context.Add(toDo);
                await _context.SaveChangesAsync();
                return response;
            }
            catch
            {
                response.Success = false;
                response.Message = "Database could not be updated";
            }
            return response;
        }


        public async Task<ServiceResponse<ToDoVM>> DeleteToDoAsync(Spartan? user, int? id)
        {
            var response = new ServiceResponse<ToDoVM>();
            var toDo = await _context.ToDoItems.FindAsync(id);
            if (user == null)
            {
                response.Success = false;
                response.Message = "No user found";
                return response;
            }
            if (toDo == null)
            {
                response.Success = false;
                response.Message = "There are no ToDo items to do!";
                return response;
            }

            if (toDo.SpartanId == user.Id)
            {
                _context.ToDoItems.Remove(toDo);
                await _context.SaveChangesAsync();
                response.Success = true;
                response.Message = "ToDo item removed";
            }
            return response;
        }


        //
        public async Task<ServiceResponse<ToDoVM>> EditToDoAsync(Spartan? user, int? id, ToDoVM todoVM)
        {
            var response = new ServiceResponse<ToDoVM>();
            if (user == null)
            {
                response.Success = false;
                response.Message = "No user found";
                return response;
            }

            var spartanOwnerId = await GetSpartanOwnerAsync(id);
            if (id != todoVM.Id)
            {
                response.Message = "Error updating";
                response.Success = false;
                return response;
            }

            var toDo = _mapper.Map<ToDo>(todoVM);
            _context.Update(toDo);
            toDo.SpartanId = user.Id;
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<ToDoVM>> GetDetailsAsync(Spartan? user, int? id, string role)
        {
            var response = new ServiceResponse<ToDoVM>();
            if (id == null || _context.ToDoItems == null)
            {
                response.Success = false;
                return response;
            }
            if (user == null)
            {
                response.Success = false;
                response.Message = "No user found";
                return response;
            }

            var todo = await _context.ToDoItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null || (todo.SpartanId != user.Id && role == "Trainee"))
            {
                response.Success = false;
                return response;
            }

            response.Data = _mapper.Map<ToDoVM>(todo);
            return response;
        }

        public string GetRole(HttpContext httpContext)
        {
            return httpContext.User.IsInRole("Trainee") ? "Trainee" : "Trainer";
        }

        public async Task<string> GetSpartanOwnerAsync(int? id)
        {
            return await _context.ToDoItems.Where(td => td.Id == id).Select(td => td.SpartanId).FirstAsync();
        }

        public async Task<ServiceResponse<IEnumerable<ToDoVM>>> GetToDoItemsAsync(Spartan? spartan, string role = "Trainee", string? filter = null)
        {
            var response = new ServiceResponse<IEnumerable<ToDoVM>>();
            if (spartan == null)
            {
                response.Success = false;
                response.Message = "Can't find Spartan";
                return response;
            }
            if (_context.ToDoItems == null)
            {
                response.Success = false;
                response.Message = "There are not todo items to do!";
                return response;
            }

            //var toDoItems = await _context.ToDoItems.Where(td => td.SpartanId == spartan.Id).ToListAsync();
            List<ToDo> toDoItems = new List<ToDo>();
            if (role == "Trainee")
            {
                // if the role is trainee
                // get the todo itemers
                // where the SpartanId of that todo item = the Id of the spartan
                toDoItems = await _context.ToDoItems.Where(td => td.SpartanId == spartan.Id).ToListAsync();
            }
            if (role == "Trainer")
            {
                // Trainer can see all the to dos!!
                toDoItems = await _context.ToDoItems.ToListAsync();
            }

            if (string.IsNullOrEmpty(filter))
            {
                response.Data = toDoItems.Select(td => _mapper.Map<ToDoVM>(td));
                return response;
            };
            response.Data = toDoItems
                .Where(td =>
                    td.Title.Contains(filter!, StringComparison.OrdinalIgnoreCase) ||
                    (td.Description?.Contains(filter!, StringComparison.OrdinalIgnoreCase) ?? false))
                .Select(td => _mapper.Map<ToDoVM>(td));

            return response;
        }

        public async Task<ServiceResponse<Spartan>> GetUserAsync(HttpContext httpContext)
        {
            var response = new ServiceResponse<Spartan>();
            
            var currentUser = await _userManager.GetUserAsync(httpContext.User);

            if (currentUser == null)
            {
                response.Success = false;
                response.Message = "Could not find Spartan";
                return response;
            }

            response.Data = currentUser;
            return response;
        }

        public bool ToDoExists(int id)
        {
            return (_context.ToDoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<ServiceResponse<ToDoVM>> UpdateToDoCompleteAsync(Spartan? user, int id, MarkCompleteVM markCompleteVM)
        {
            var response = new ServiceResponse<ToDoVM>();
            if (user == null)
            {
                response.Success = false;
                response.Message = "No user found";
                return response;
            }
            if (id != markCompleteVM.Id)
            {
                response.Success = false;
                response.Message = "Model error";
                return response;
            }
            var todo = await _context.ToDoItems.FindAsync(id);

            if (todo == null)
            {
                response.Success = false;
                response.Message = "Cannot find ToDo item";
                return response;
            }
            if (todo == null || todo.SpartanId != user.Id)
            {
                response.Success = false;
                return response;
            }
            todo.Complete = markCompleteVM.Complete;

            await _context.SaveChangesAsync();
            return response;
        }
    }
}
