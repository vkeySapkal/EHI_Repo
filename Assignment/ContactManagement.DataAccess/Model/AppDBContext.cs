using Microsoft.EntityFrameworkCore;

namespace contactManagement.Model
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet <Contact> contacts { get; set; }
    }
}
