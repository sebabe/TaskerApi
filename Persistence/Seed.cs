using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager){
            if (context.AppTasks.Any()) return;
            
            var AppTasks = new List<AppTask>{
                new AppTask
                {
                    Title = "Title 1",
                    Description = "Description 1",
                    CreateDate = DateTime.UtcNow,
                },
                new AppTask
                {
                    Title = "Title 2",
                    Description = "Description 2",
                    CreateDate = DateTime.UtcNow,
                },
                new AppTask
                {
                    Title = "Title 3",
                    Description = "Description 3",
                    CreateDate = DateTime.UtcNow,
                },
            };

            await context.AppTasks.AddRangeAsync(AppTasks);
            await context.SaveChangesAsync();
            if (!userManager.Users.Any()) return;

            var appUsers = new List<AppUser>{
                new AppUser{
                    UserName = "Admin",
                    Email = "Email@gmail.com",
                    DisplayName = "Admin",
                }
            };
            foreach (var appUser in appUsers)
            {
                await userManager.CreateAsync(appUser, "Pa$$w0rd");
            }

        }
    }
}