using Anabi.Domain.Enums;
using Anabi.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Anabi.Infrastructure
{
    public static class SecuritySetup
    {
        public static void AddAnabiSecurityServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IAnabiCrypt, AnabiCrypt>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = configuration["Jwt:Issuer"],
                            ValidAudience = configuration["Jwt:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                        };
                    });

            services.AddAuthorization(options =>
            {
                foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
                {
                    string roleName = role.ToString();
                    options.AddPolicy(roleName, policy => policy.RequireRole(roleName));
                }
            });


        }
    }
}
