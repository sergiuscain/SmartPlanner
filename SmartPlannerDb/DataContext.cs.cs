using Microsoft.EntityFrameworkCore;
using SmartPlanner.Data.Entities;

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
