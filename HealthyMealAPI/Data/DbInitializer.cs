using HealthyMealAPI.Entities;

namespace HealthyMealAPI.Data
{
    public static class DbInitializer
    {
        /// <summary>
        /// Инициализирует передаваемый контекст БД значениями по умолчанию если в нём нет данных
        /// </summary>
        /// <param name="context">Контекст БД</param>
        /// <returns></returns>
        public static async Task Initialize(HealthyMealContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (!context.EatingTypes.Any())
                {
                    var eatingTypes = new EatingType[]
                    {
                        new EatingType { Id = "default_breakfast", Name = "Завтрак"},
                        new EatingType { Id = "default_lunch", Name = "Обед" },
                        new EatingType { Id = "default_dinner", Name = "Ужин" },
                        new EatingType { Id = "default_snack", Name = "Перекус" }
                    };

                    foreach (EatingType eatingType in eatingTypes)
                    {
                        context.EatingTypes.Add(eatingType);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.Foods.Any())
                {
                    var foods = new Food[]
                    {
                        new Food { Id = "deafault_soup"  },
                        new Food {  Id = "default_cookie" }
                    };

                    foreach (Food food in foods)
                    {
                        context.Foods.Add(food);
                    }
                    await context.SaveChangesAsync();
                }

                
                if (!context.Recipes.Any())
                {
                    var recipes = new Recipe[]
                    {
                        new Recipe
                        {
                            Id = "default_vegsoup",
                            UserId = "Common",
                            FoodId = "deafault_soup",
                            Name = "Овощной суп",
                            Image = await File.ReadAllBytesAsync("D:\\University\\7 семестр\\Мобилки\\vegetablesSoup.jpg"),
                            CookingTime = new DateTime(1999, 1, 1, 1, 0, 0),
                            Description = "ОВОЩИ, СУП, ОВОЩНОЙ, ОВОЩНОЙ СУП"
                        },
                        new Recipe
                        {
                            Id = "default_cookielean",
                            UserId = "Common",
                            FoodId = "default_cookie",
                            Name = "Печенье постное",
                            Image = await File.ReadAllBytesAsync("D:\\University\\7 семестр\\Мобилки\\cookies.jpg"),
                            CookingTime = new DateTime(1999, 1, 1, 1, 30, 0),
                            Description = "ПЕЧЕНЬЕ, ПОСТНОЕ, ПОСТНОЕ ПЕЧЕНЬЕ"
                        }
                    };

                    foreach (Recipe recipe in recipes)
                    {
                        context.Recipes.Add(recipe);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Menus.Any())
                {
                    var menus = new Menu[]
                    {
                        new Menu
                        {
                            Id = "default_menu",
                            UserId = "c8a0d1c5-dbd3-4c5c-ad34-031b86047b87",
                            Date = DateTime.Now,
                            Kcal = 1000,
                            Proteins = 100,
                            Fats = 200,
                            Carbohydrates = 700,
                        }
                    };

                    foreach (Menu menu in menus)
                    {
                        context.Menus.Add(menu);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.MenuStrings.Any())
                {
                    var menuStrings = new MenuString[]
                    {
                        new MenuString
                        {
                            Id = "string1",
                            EatingTypeId = "default_breakfast",
                            RecipeId = "default_vegsoup",
                            MenuId = "default_menu",
                        },
                        new MenuString
                        {
                            Id = "string2",
                            EatingTypeId = "default_breakfast",
                            RecipeId = "default_cookielean",
                            MenuId = "default_menu",
                        }
                    };

                    foreach (MenuString menuString in menuStrings)
                    {
                        context.MenuStrings.Add(menuString);
                    }
                    await context.SaveChangesAsync();
                }

                

            }
            catch
            {
                throw;
            }
        }
    }
}
