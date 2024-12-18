using Microsoft.AspNetCore.Identity;
using SmartPlannerDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPlannerDb
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@admin.admin";
            string startAdminPasswor = "@Admin2024!!"; //Стартовый пароль, его надо поменять после первого захода из под админа!!
            string adminRole = Constants.Roles.Admin.ToString();
            string userRole = Constants.Roles.User.ToString();
            string delevoperRole = Constants.Roles.Developer.ToString();


            if (roleManager.FindByNameAsync(adminRole).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(adminRole)).Wait();
            }
            if (roleManager.FindByNameAsync(userRole).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(userRole)).Wait();
            }
            if (roleManager.FindByNameAsync(delevoperRole).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(delevoperRole)).Wait();
            }
            if (userManager.FindByEmailAsync(adminEmail).Result == null)
            {
                var user = new User
                {
                    Email = adminEmail,
                    Name = "Admin001",
                    Sex = "M",
                    DateOfBirth = DateTime.Now,
                };
                var result = userManager.CreateAsync(user, startAdminPasswor).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, adminRole).Wait();
                }
            }

        }
    }
}
