using Microsoft.EntityFrameworkCore;
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
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connrectionString));  //Добавление контекста базы данных
            builder.Services.AddIdentity<User, IdentityRole>()  //Добавление Identity 
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();   //Добавление стандартного токена для сброса пароля/Email
            builder.Services.AddTransient<INotesStorage, NotesStorage>(); //Сервис для работы с заметками. (Хранилище заметок)
            builder.Services.AddTransient<ITasksStorage, TasksStorage>(); //Сервис для работы с задачами

            //Настройка куки
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true; // Устанавливаем HttpOnly для безопасности
                options.ExpireTimeSpan = TimeSpan.FromDays(30);  //Время жизни куки (30 дней)
                options.SlidingExpiration = true;
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied"; // Путь при доступе к защищенным ресурсам

            });
        }
    }
}