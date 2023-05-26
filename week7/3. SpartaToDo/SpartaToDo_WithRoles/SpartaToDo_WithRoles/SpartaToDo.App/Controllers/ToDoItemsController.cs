using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpartaToDo.App.Models;
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

        [Authorize(Roles = "Trainee, Trainer")]

        public async Task<IActionResult> Index(string? filter = null)
        {
            var user = await _service.GetUserAsync(HttpContext);
            var response = await _service.GetToDoItemsAsync(user.Data, _service.GetRole(HttpContext),filter);
            return response.Success ? View(response.Data) : Problem(response.Message);
        }

        [Authorize(Roles = "Trainee, Trainer")]
        public async Task<IActionResult> Details(int? id)
        {
            var currentUser = await _service.GetUserAsync(HttpContext);
            var response = await _service.GetDetailsAsync(currentUser.Data, _service.GetRole(HttpContext), id);
            return response.Success ? View(response.Data) : Problem(response.Message);
        }

        [Authorize(Roles = "Trainee")]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainee")]

        public async Task<IActionResult> Create(CreateToDoVM createToDoVM)
        {

            var currentUser = await _service.GetUserAsync(HttpContext);
            var response = await _service.CreateToDoAsync(currentUser.Data, createToDoVM);
            return response.Success ? RedirectToAction(nameof(Index)) : View(createToDoVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainee")]

        public async Task<IActionResult> Edit(int id, ToDoVM todoVM)
        {
            var currentUser = await _service.GetUserAsync(HttpContext);
            var response = await _service.EditToDoAsync(currentUser.Data, id, todoVM);
            return response.Success ? RedirectToAction(nameof(Index)) : Problem(response.Message);
        }

        [HttpGet]
        [Authorize(Roles = "Trainee")]

        public async Task<IActionResult> Edit(int? id)
        {
            var currentUser = await _service.GetUserAsync(HttpContext);
            var response = await _service.GetDetailsAsync(currentUser.Data, _service.GetRole(HttpContext), id);
            return response.Success ? View(response.Data) : NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainee")]

        public async Task<IActionResult> Delete(int? id)
        {

            var currentUser = await _service.GetUserAsync(HttpContext);
            var response = await _service.DeleteToDoAsync(currentUser.Data, id);
            return response.Success ? RedirectToAction(nameof(Index)) : Problem(response.Message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainee")]

        public async Task<IActionResult> UpdateTodoComplete(int id, MarkCompleteVM markCompleteVM)
        {
            var currentUser = await _service.GetUserAsync(HttpContext);
            var response = await _service.UpdateToDoCompleteAsync(currentUser.Data, id, markCompleteVM);
            return response.Success ? RedirectToAction(nameof(Index)) : Problem(response.Message);

        }
    }
}
