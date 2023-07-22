using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class AppDbConextcs : IdentityDbContext<AppUser>
    {
        public AppDbConextcs(DbContextOptions<AppDbConextcs> options) : base(options)
        {

        }

        //public DbSet<AppUser> appUsers { get; set; }
        public DbSet<AppTask> appTasks { get; set; }
    }
}
