using Quizzely.Repository.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Qizzely.API.Extensions;
using Quizzely.Core.Interfaces.Repositories;
using Quizzely.Repository.Repositories;
using Quizzely.Core.Interfaces.Services;
using Quizzely.Services.ExamServicee;
using System.Reflection;
using MoECommerce.Repository.Data.Contexts;
using MoECommerce.Core.Interfaces.Services;
using Quizzely.Services;

namespace Qizzely.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<SqlDataContext>( opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
            });

            builder.Services.AddDbContext<IdentityDataContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySqlConnection"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IExamService, ExamService>();

            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddIdentityService(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            await DbInitializer.InitializeDbAsync(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
