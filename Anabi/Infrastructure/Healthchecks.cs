using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Anabi.Infrastructure
{
    public static class Healthchecks
    {
        public static void UseAnabiHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health/api", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecks("/health/sql", new HealthCheckOptions()
            {
                Predicate = p => p.Name.Equals("sql"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI();
        }

        public static void AddAnabiHealthChecks(this IServiceCollection services, IConfigurationRoot configuration, IHostingEnvironment environment)
        {
            var connection = configuration.GetConnectionString("AnabiDatabase");

            services.AddHealthChecks()
                .AddSqlServer(
                connectionString: connection,
                healthQuery: "Select 1",
                name: "sql",
                failureStatus: HealthStatus.Unhealthy,
                tags: new string[] {"sql", "sqlserver", "database"}
                );

            if (!environment.EnvironmentName.Equals("Test"))
            {
                services.AddHealthChecksUI();
            }
        }
    }
}
