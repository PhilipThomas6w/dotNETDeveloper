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
        public async Task<IActionResult> Index()
        {
              return _context.ToDoItems != null ? 
                          View(await _context.ToDoItems.Select(td => _mapper.Map<ToDoVM>(td)).ToListAsync()) :
                          Problem("Entity set 'SpartaToDoContext.ToDoItems'  is null.");
        }

        // GET: ToDoItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToDoItems == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDoItems
                .Select(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            var toDoVM = _mapper.Map<ToDoVM>(toDo);

            return View(toDoVM);
        }

        // GET: ToDoItems/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: ToDoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateToDoVM toDoVM)
        {
            if (ModelState.IsValid)
            {
                var toDo = _mapper.Map<ToDo>(toDoVM);
                _context.Add(toDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoVM);
        }

        // GET: ToDoItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDoItems == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDoItems.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<ToDoVM>(toDo));
        }

        // POST: ToDoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Complete,DateCreated")] ToDoVM toDo)
        {
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.Id))
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
            return View(toDo);
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
