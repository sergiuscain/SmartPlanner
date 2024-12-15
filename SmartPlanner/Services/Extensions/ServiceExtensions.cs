using Microsoft.Extensions.DependencyInjection;

namespace SmartPlanner.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Add your services here
            services.AddControllersWithViews();
        }
    }
}