using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class ProductDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
        }
    }
}