using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context){
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
        }
    }
}