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

namespace SpartaToDo.App.Controllers
{
    public class ToDoItemsController : Controller
    {
        private readonly SpartaToDoContext _context;
        private readonly IMapper _mapper;

        public ToDoItemsController(SpartaToDoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: ToDoItems
        public async Task<IActionResult> Index(string filter)
        {
            if (_context.ToDoItems == null)

            {

                return Problem("There are not todo items to do!");

            }

            var toDoItems = await _context.ToDoItems.Select(td => _mapper.Map<ToDoVM>(td)).ToListAsync();



            if (string.IsNullOrEmpty(filter))

            {

                return View(toDoItems);

            };



            return View(toDoItems.Where(td =>

                    td.Title.Contains(filter!, StringComparison.OrdinalIgnoreCase) ||

                    (td.Description?.Contains(filter!, StringComparison.OrdinalIgnoreCase) ?? false))

                .Select(td => _mapper.Map<ToDoVM>(td)));

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
            if (id != todoVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<ToDo>(todoVM));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(todoVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todoVM);
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

        private bool ToDoExists(int id)
        {
            return (_context.ToDoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        
    }
}
