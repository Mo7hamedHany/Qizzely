﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MoECommerce.Repository.Data.Contexts;
using System.Text;

namespace Qizzely.API.Extensions
{
    public static class IdentityServicesExtension
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddSignInManager<SignInManager<IdentityUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                    ValidateAudience = true,
                    ValidAudience = configuration["Token:Audience"],
                    ValidateLifetime = true,

                });

            return services;
        }
    }
}
