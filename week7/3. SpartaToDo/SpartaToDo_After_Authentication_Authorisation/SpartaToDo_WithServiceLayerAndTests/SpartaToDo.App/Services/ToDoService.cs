using AutoMapper;
using Azure;
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
        public ToDoService(SpartaToDoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ToDoVM>> CreateToDoAsync(CreateToDoVM createTodoVM)
        {
            var response = new ServiceResponse<ToDoVM>();
            if (_context.ToDoItems == null)
            {
                response.Success = false;
                response.Message = "There are no ToDo items to do!";
                return response;
            }


            try
            {
                _context.Add(_mapper.Map<ToDo>(createTodoVM));
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

        public async Task<ServiceResponse<ToDoVM>> DeleteToDoAsync(int? id)
        {
            var response = new ServiceResponse<ToDoVM>();

            if (_context.ToDoItems == null)
            {
                response.Success = false;
                response.Message = "There are no ToDo items to do!";
                return response;
            }
            var toDo = await _context.ToDoItems.FindAsync(id);

            if (toDo == null)
            {
                response.Success = false;
                response.Message = "There are no ToDo items to do!";
                return response;
            }
            _context.ToDoItems.Remove(toDo);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "ToDo item removed";


            return response;
        }

        //
        public async Task<ServiceResponse<ToDoVM>> EditToDoAsync(int? id, ToDoVM todoVM)
        {
            var response = new ServiceResponse<ToDoVM>();
            if (id != todoVM.Id)
            {
                response.Message = "Error updating";
                response.Success = false;
                return response;
            }

            var toDo = _mapper.Map<ToDo>(todoVM);
            _context.Update(toDo);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<ToDoVM>> GetDetailsAsync(int? id)
        {
            var response = new ServiceResponse<ToDoVM>();
            if (id == null || _context.ToDoItems == null)
            {
                response.Success = false;
                return response;
            }

            var todo = await _context.ToDoItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                response.Success = false;
                return response;
            }
            response.Data = _mapper.Map<ToDoVM>(todo);
            return response;
        }


        public async Task<ServiceResponse<IEnumerable<ToDoVM>>> GetToDoItemsAsync(string? filter = null)
        {
            var response = new ServiceResponse<IEnumerable<ToDoVM>>();

            if (_context.ToDoItems == null)
            {
                response.Success = false;
                response.Message = "There are not todo items to do!";
                return response;
            }

            var toDoItems = await _context.ToDoItems.ToListAsync();

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

        public bool ToDoExists(int id)
        {
            return (_context.ToDoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<ServiceResponse<ToDoVM>> UpdateToDoCompleteAsync(int id, MarkCompleteVM markCompleteVM)
        {
            var response = new ServiceResponse<ToDoVM>();

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
            todo.Complete = markCompleteVM.Complete;

            await _context.SaveChangesAsync();
            return response;
        }
    }
}
