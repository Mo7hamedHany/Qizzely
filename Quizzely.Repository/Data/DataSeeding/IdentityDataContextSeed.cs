using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzely.Repository.Data.DataSeeding
{
    public static class IdentityDataContextSeed
    {
        public static async Task SeedUserAsync(UserManager<IdentityUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new IdentityUser
                {
                    UserName = "MohamedHany",
                    Email = "hanykasim.tawfik@gmail.com",
                };

                await userManager.CreateAsync(user,"P@ssw0rd12345");
            }
        }
    }
}
