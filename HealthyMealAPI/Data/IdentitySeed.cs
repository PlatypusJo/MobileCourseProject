using HealthyMealAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace BackAPI.Data
{
    public static class IdentitySeed
    {
        /// <summary>
        /// Создание ролей пользователей (админ и обычный пользователь), создаёт объекты с такими ролями если их нет
        /// </summary>
        /// <param name="serviceProvider">Стандартный набор сервисов</param>
        /// <returns></returns>
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            // Создание ролей администратора и пользователя
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            // Создание Администратора
            string adminEmail = "admin@mail.com";
            string adminPassword = "Admin_123";
            string sex = "Админ";
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail, Sex = sex };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
            // Создание Пользователя
            string userEmail = "user@mail.com";
            string userPassword = "User_123";
            string userSex = "Мужской";
            string userName = "Ohleg";
            double kcalGoal = 1800;
            double normalKcal = 2500;
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                User user = new User { Email = userEmail, UserName = userName, Sex = userSex, KcalGoal = kcalGoal, NormalKcal = normalKcal };
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }

            string commonEmail = "Common";
            string commonPass = "User_Com0n01";
            string commonSex = "common";
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                User user = new User { Id = "Common", Email = commonEmail, UserName = commonEmail, Sex = commonSex };
                IdentityResult result = await userManager.CreateAsync(user, commonPass);
            }
        }
    }
}
