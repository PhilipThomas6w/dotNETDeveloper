using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            var roleStore = new RoleStore<IdentityRole>(context);


            if (context.Spartans.Any())
            {
                context.Spartans.RemoveRange(context.Spartans);
                context.ToDoItems.RemoveRange(context.ToDoItems);
                context.UserRoles.RemoveRange(context.UserRoles);
                context.Roles.RemoveRange(context.Roles);
                context.SaveChanges();
            }


            var trainer = new IdentityRole
            {
                Name = "Trainer",
                NormalizedName = "TRAINER"
            };
            var trainee = new IdentityRole
            {
                Name = "Trainee",
                NormalizedName = "TRAINEE"
            };


            roleStore
              .CreateAsync(trainer)
              .GetAwaiter()
              .GetResult();
            roleStore
                .CreateAsync(trainee)
                .GetAwaiter()
                .GetResult();

            var phil = new Spartan
            {
                UserName = "Phil@spartaglobal.com",
                Email = "Phil@spartaglobal.com",
                EmailConfirmed = true
            };
            var nish = new Spartan
            {
                UserName = "Nish@spartaglobal.com",
                Email = "Nish@spartaglobal.com",
                EmailConfirmed = true,
            };
            var peter = new Spartan
            {
                UserName = "Peter@spartaglobal.com",
                Email = "Peter@spartaglobal.com",
                EmailConfirmed = true
            };

            userManager
                .CreateAsync(phil, "Password1!")
                .GetAwaiter()
                .GetResult();
            userManager
                .CreateAsync(nish, "Password1!")
                .GetAwaiter()
                .GetResult();
            userManager
                .CreateAsync(peter, "Password1!")
                .GetAwaiter()
                .GetResult();

            context.UserRoles.AddRange(new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(phil).Result,
                    RoleId = roleStore.GetRoleIdAsync(trainer).Result
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(nish).Result,
                    RoleId = roleStore.GetRoleIdAsync(trainee).Result
                },
               new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(peter).Result,
                    RoleId = roleStore.GetRoleIdAsync(trainee).Result
                }

            });



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
                    Spartan = peter

                },
                new ToDo
                {
                    Title = "Create Repo",
                    Description = "Create repository on GitHub for this week",
                    Complete = true,
                    DateCreated = new DateTime(2023, 01, 02),
                    Spartan = peter
                }
            );
            context.SaveChanges();
        }
    }
}