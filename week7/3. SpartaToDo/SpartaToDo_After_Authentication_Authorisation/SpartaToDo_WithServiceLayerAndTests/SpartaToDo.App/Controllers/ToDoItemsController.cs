using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpartaToDo.App.Models.ViewModels;
using SpartaToDo.App.Services;

namespace SpartaToDo.App.Controllers
{
    [Authorize]
    public class ToDoItemsController : Controller
    {
        private readonly IToDoService _service;

        public ToDoItemsController(IToDoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string? filter = null)
        {
            var response = await _service.GetToDoItemsAsync(filter);
            return response.Success ? View(response.Data) : Problem(response.Message);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var response = await _service.GetDetailsAsync(id);
            return response.Success ? View(response.Data) : Problem(response.Message);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateToDoVM createToDoVM)
        {

            var response = await _service.CreateToDoAsync(createToDoVM);
            return response.Success ? RedirectToAction(nameof(Index)) : View(createToDoVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToDoVM todoVM)
        {
            var response = await _service.EditToDoAsync(id, todoVM);
            return response.Success ? RedirectToAction(nameof(Index)) : Problem(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var response = await _service.GetDetailsAsync(id);
            return response.Success ? View(response.Data) : NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            var response = await _service.DeleteToDoAsync(id);
            return response.Success ? RedirectToAction(nameof(Index)) : Problem(response.Message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTodoComplete(int id, MarkCompleteVM markCompleteVM)
        {
            var response = await _service.UpdateToDoCompleteAsync(id, markCompleteVM);
            return response.Success ? RedirectToAction(nameof(Index)) : Problem(response.Message);

        }

        private bool ToDoExists(int id)
        {
            return _service.ToDoExists(id);
        }
    }
}
