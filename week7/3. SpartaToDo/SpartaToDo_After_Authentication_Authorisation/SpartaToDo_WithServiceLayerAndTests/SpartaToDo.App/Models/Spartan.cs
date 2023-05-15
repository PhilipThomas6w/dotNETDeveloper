using Microsoft.AspNetCore.Identity;

namespace SpartaToDo.App.Models
{
    public class Spartan : IdentityUser
    {
        public List<ToDo>? ToDoItems  { get; set; }
    }
}
