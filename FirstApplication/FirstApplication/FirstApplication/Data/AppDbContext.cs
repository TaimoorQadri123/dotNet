using FirstApplication.Models;
using Microsoft.EntityFrameworkCore;
namespace FirstApplication.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {
        
        }
        public DbSet<Students> Students { get; set; }   
    }
}
