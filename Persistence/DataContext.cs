using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>   
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppTask> AppTasks { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}