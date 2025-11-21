using Microsoft.EntityFrameworkCore;
using ModelHandling.Models;

namespace ModelHandling.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Students>  Students { get; set; }

        public DbSet<Category> Category { get; set; }   

        public DbSet<Products> Products { get; set; }   

    }
}
