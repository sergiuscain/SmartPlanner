using Microsoft.AspNetCore.Identity;
using SmartPlanner.Services.Extensions;
using SmartPlannerDb;
using SmartPlannerDb.Entities;

namespace SmartPlanner
{
    public class Program
    {
        public static  void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.ConfigureServices();

            var app = builder.Build();

            using(var serciceScope = app.Services.CreateScope())
            {
                var sercive = serciceScope.ServiceProvider;
                var userManager = sercive.GetRequiredService<UserManager<User>>();
                var roleManager = sercive.GetRequiredService<RoleManager<IdentityRole>>();
                IdentityInitializer.Initialize(userManager, roleManager);
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
