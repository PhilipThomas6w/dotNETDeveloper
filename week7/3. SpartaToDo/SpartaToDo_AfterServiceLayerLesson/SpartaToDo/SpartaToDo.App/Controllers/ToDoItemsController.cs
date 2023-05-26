using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpartaToDo.App.Data;
using SpartaToDo.App.Models;
using SpartaToDo.App.Models.ViewModels;
using SpartaToDo.App.Services;

namespace SpartaToDo.App.Controllers
{
    public class ToDoItemsController : Controller
    {
        private readonly SpartaToDoContext _context;
        private readonly IMapper _mapper;
        private readonly IToDoService _service;

       
        public ToDoItemsController(SpartaToDoContext context, IMapper mapper, IToDoService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        // GET: ToDoItems
        public async Task<IActionResult> Index(string filter = null)
        {
            var response = await _service.GetToDoItemsAsync(filter);
            return response.Success ? View(response.Data) : Problem(response.Message);
        }

        // GET: ToDoItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToDoItems == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDoItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ToDoVM>(toDo));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTodoComplete(int id, MarkCompleteVM markCompleteVM)
        {
            if (id != markCompleteVM.Id)
            {
                return NotFound();
            }
            var todo = await _context.ToDoItems.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.Complete = markCompleteVM.Complete;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ToDoItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Complete,DateCreated")] CreateToDoVM createTodo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<ToDo>(createTodo));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createTodo);
        }

        // GET: ToDoItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var todo = await _context.ToDoItems.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<ToDoVM>(todo));
        }
        // POST: ToDoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToDoVM todoVM)
        {
            var response = await _service.EditToDoAsync(id, todoVM);
            return response.Success ? RedirectToAction(nameof(Index)) : Problem(response.Message);
        }

        // GET: ToDoItems/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            var toDo = await _context.ToDoItems.FindAsync(id);
            _context.ToDoItems.Remove(toDo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool ToDoExists(int id)
        //{
        //    return _service.ToDoExists(id);
        //}
    }
}
