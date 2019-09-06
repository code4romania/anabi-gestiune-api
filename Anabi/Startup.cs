using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using Anabi.Domain;
using AutoMapper;
using MediatR;
using Anabi.Middleware;
using Anabi.Security;
using Anabi.Infrastructure;

namespace Anabi
{
    public class Startup
    {
        public IHostingEnvironment CurrentEnvironment { get; }

        public Startup(IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "anabi-apilog-{Date}.txt"))
                .CreateLogger();

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            CurrentEnvironment = env;
            
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAnabiLoggingServices();

            services.AddAnabiSecurityServices(Configuration);

            // Add framework services.
            services.AddAnabiFrameworkServices();

            services.AddAnabiUserInfoServices();

            services.AddAnabiDbContext(Configuration);

            services.AddAnabiSwaggerServices();

            services.AddAnabiValidationServices();

            services.AddAutoMapper(typeof(Startup), typeof(BaseHandler));

            services.AddMediatR(typeof(Startup), typeof(BaseHandler), typeof(PasswordHashHandler));

            services.AddAnabiCachingServices();
            //services.AddAnabiHealthChecks(Configuration, CurrentEnvironment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {

            app.UseAnabiExceptionResponse();

            app.UseAnabiCorsSetup();

            app.UseAuthentication();

            app.UseMvc();

            app.UseAnabiSwaggerMiddleware();

            //app.UseAnabiHealthChecks();
            
        }
    }
}
