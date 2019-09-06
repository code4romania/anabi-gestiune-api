using Anabi.DataAccess.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Anabi.Infrastructure
{
    public static class DbContextSetup
    {
        public static void AddAnabiDbContext(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var connection = configuration.GetConnectionString("AnabiDatabase");

            services.AddDbContext<AnabiContext>(options =>
            options
                .UseSqlServer(connection,
                             sqlServerOptionsAction: sqlOptions =>
                             {
                                 sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,

                                 maxRetryDelay: TimeSpan.FromSeconds(15),

                                 errorNumbersToAdd: null);

                             }));
        }
    }
}
