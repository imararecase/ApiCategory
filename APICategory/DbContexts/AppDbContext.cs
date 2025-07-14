using APICategory.Models;
using Microsoft.EntityFrameworkCore;

namespace APICategory.DbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
    }
}
