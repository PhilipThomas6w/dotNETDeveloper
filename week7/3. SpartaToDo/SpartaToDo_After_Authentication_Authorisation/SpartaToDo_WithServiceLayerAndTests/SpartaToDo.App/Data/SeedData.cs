using Microsoft.AspNetCore.Identity;
using SpartaToDo.App.Models;
using System.Diagnostics.Metrics;
namespace SpartaToDo.App.Data
{
    public class SeedData
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<SpartaToDoContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Spartan>>();
            if (context.Spartans.Any())
            {
                return;
            }
            var phil = new Spartan
            {
                UserName = "Phil@spartaglobal.com",
                Email = "Nish@spartaglobal.com",
                EmailConfirmed = true
            };
            var nish = new Spartan
            {
                UserName = "Nish@spartaglobal.com",
                Email = "Nish@spartaglobal.com",
                EmailConfirmed = true,
            };
            userManager
                .CreateAsync(phil, "Password1!")
                .GetAwaiter()
                .GetResult();
            userManager
                .CreateAsync(nish, "Password1!")
                .GetAwaiter()
                .GetResult();
            context.ToDoItems.AddRange(
                new ToDo
                {
                    Title = "Complete survey",
                    Description = "Complete the weekly survey",
                    Complete = false,
                    DateCreated = new DateTime(2023, 01, 03),
                    Spartan = nish
                },
                new ToDo
                {
                    Title = "Timecards",
                    Description = "Complete timecard for this week",
                    Complete = true,
                    DateCreated = new DateTime(2023, 01, 05),
                    Spartan = nish
                },
                new ToDo
                {
                    Title = "Friday stand-up",
                    Description = "Do the academy stand-up on Friday",
                    Complete = false,
                    DateCreated = new DateTime(2023, 01, 03),
                    Spartan = nish
                },
                new ToDo
                {
                    Title = "Trainee Tracker",
                    Description = "Complete start, stop, continue for this week",
                    Complete = false,
                    DateCreated = new DateTime(2023, 01, 05),
                    Spartan = phil
                },
                new ToDo
                {
                    Title = "Create Repo",
                    Description = "Create repository on GitHub for this week",
                    Complete = true,
                    DateCreated = new DateTime(2023, 01, 02),
                    Spartan = phil
                }
            );
            context.SaveChanges();
        }
    }
}