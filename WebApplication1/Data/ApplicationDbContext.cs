using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasData(
                new Film { Id = 1,Title = "killers1", Category = "Action", },
                new Film { Id = 2, Title = "killers1", Category = "SciFi" },
                new Film { Id = 3, Title = "Hannibal", Category = "History" }
                );
        }

    }
}
