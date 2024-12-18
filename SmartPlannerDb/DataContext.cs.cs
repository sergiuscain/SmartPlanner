using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartPlannerDb.Model;

namespace SmartPlannerDb
{
    public class DataContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
