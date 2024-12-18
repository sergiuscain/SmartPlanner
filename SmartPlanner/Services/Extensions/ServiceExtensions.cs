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
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            // Add your services here
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<INotesStorage, NotesStorage>();
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(15);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.Cookie = new CookieBuilder()
                {
                    IsEssential = true
                };
            });

        }
    }
}