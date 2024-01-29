using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Identity;

namespace Portfolio.Classes
{
    public static class SeedData
    {
        public async static Task GenerateFirstUser(UserManager<User> userManager)
        {
            if (await userManager.FindByNameAsync("Admin") is null)
            {
                var user = new User
                {
                    UserName = "Admin",
                    Email = "baharragayeva@gmail.com"
                };

                IdentityResult result = await userManager.CreateAsync(user, "Portfolio123!@#");
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

        }
    }
}
