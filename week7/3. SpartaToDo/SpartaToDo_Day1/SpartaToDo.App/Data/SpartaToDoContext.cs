using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpartaToDo.App.Models;

namespace SpartaToDo.App.Data
{
    public class SpartaToDoContext : IdentityDbContext
    {
        public SpartaToDoContext(DbContextOptions<SpartaToDoContext> options)
            : base(options)
        {
        }

        public DbSet<ToDo> ToDoItems { get; set; }
    }
}