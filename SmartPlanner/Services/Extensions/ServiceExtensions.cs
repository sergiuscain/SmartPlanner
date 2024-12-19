using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartPlannerDb.Model;
using SmartPlanner;
using SmartPlannerDb;
using SmartPlannerDb.Entities;
using Microsoft.AspNetCore.Identity;

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
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddTransient<INotesStorage, NotesStorage>();

        }
    }
}