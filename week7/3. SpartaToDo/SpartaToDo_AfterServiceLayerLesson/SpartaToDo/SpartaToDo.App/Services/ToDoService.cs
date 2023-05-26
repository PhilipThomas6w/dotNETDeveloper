using AutoMapper;
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
        public Task<ToDoVM> CreateToDoAsync(CreateToDoVM createTodoVM)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoVM> DeleteToDoAsync(int? id)
        {
            throw new NotImplementedException();
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
            try
            {
                var toDo = _mapper.Map<ToDo>(todoVM);
                _context.Update(toDo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!ToDoExists(todoVM.Id))
                {
                    response.Success = false;
                    return response;
                }
                else
                {
                    throw;
                }
            }
            return response;
        }

        public Task<ToDoVM> GetDetailsAsync(int? id)
        {
            throw new NotImplementedException();
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

        public Task<ToDoVM> UpdateToDoCompleteAsync(int id, MarkCompleteVM markCompleteVM)
        {
            throw new NotImplementedException();
        }
    }
}
