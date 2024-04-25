using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoECommerce.Repository.Data.Contexts;
using Quizzely.Repository.Data.Contexts;
using Quizzely.Repository.Data.DataSeeding;

namespace Qizzely.API.Extensions
{
    public static class DbInitializer
    {
        public static async Task InitializeDbAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();
                var context = service.GetRequiredService<SqlDataContext>();
                var identityContext = service.GetRequiredService<UserManager<IdentityUser>>();

                try
                {
                    if ((await context.Database.GetPendingMigrationsAsync()).Any()) 
                    {
                       await context.Database.MigrateAsync();
                    }

                    await DataContextSeed.DataSeed(context);
                    await IdentityDataContextSeed.SeedUserAsync(identityContext);
                }
                catch (Exception ex)
                {

                    var logger = loggerFactory.CreateLogger<Program>();

                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
