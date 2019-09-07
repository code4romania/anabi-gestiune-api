using Anabi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Anabi.Infrastructure
{
    public static class SwaggerSetup
    {
        public static void AddAnabiSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen((c) =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "ANABI", Version = "v1" });
                c.DescribeAllEnumsAsStrings();
                c.OperationFilter<AddAuthorizationHeaderFilter>();
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Anabi.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.ConfigureSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
            });
        }

        public static void UseAnabiSwaggerMiddleware(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ANABI API V1");

            });
        }
    }
}
