using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartPlanner.Data;

namespace SmartPlanner.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            string connrectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            // Add your services here
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connrectionString));
            builder.Services.AddTransient<INotesStorage, NotesStorage>();

        }
    }
}