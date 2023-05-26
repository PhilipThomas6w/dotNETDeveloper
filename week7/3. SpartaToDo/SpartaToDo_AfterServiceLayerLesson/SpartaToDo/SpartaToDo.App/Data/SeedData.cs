using SpartaToDo.App.Models;

namespace SpartaToDo.App.Data
{
    public class SeedData
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            /*retrieves an instance of the `SpartaToDoContext` class from the service provider. The `GetRequiredService<T>` method is used to retrieve a service of the specified type `T`, throwing an exception if the service is not registered. (reword)*/
            var context = serviceProvider.GetRequiredService<SpartaToDoContext>();

            if (context.ToDoItems.Any())
            {
                return; 
            }

            context.ToDoItems.AddRange(
                new ToDo
                {
                    Title = "Complete survey",
                    Description = "Complete the weekly survey",
                    Complete = false,
                    DateCreated = new DateTime(2023, 01, 03)
                },
                new ToDo
                {
                    Title = "Timecards",
                    Description = "Complete timecard for this week",
                    Complete = true,
                    DateCreated = new DateTime(2023, 01, 05)
                },
                new ToDo
                {
                    Title = "Friday stand-up",
                    Description = "Do the academy stand-up on Friday",
                    Complete = false,
                    DateCreated = new DateTime(2023, 01, 03)
                }
            );
            context.SaveChanges();
        }
    }
}
