using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Anabi.DataAccess.Ef;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Serilog;
using System.IO;
using System.Security.Principal;
using Anabi.Domain;
using Anabi.Domain.Category.Commands;
using AutoMapper;
using MediatR;
using FluentValidation.AspNetCore;
using Anabi.Domain.Common;
using Anabi.Middleware;
using Anabi.Filters;

using Anabi.Domain.Common.Address;
using FluentValidation;

using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Anabi.Domain.Enums;
using Anabi.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Anabi.Security;
using Anabi.Validators;
using Anabi.Validators.Interfaces;

namespace Anabi
{
    public class Startup
    {
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

            
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
                                    loggingBuilder
                                    .AddSerilog(dispose: true)
                                    .AddConsole());

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer              = true,
                    ValidateAudience            = true,
                    ValidateLifetime            = true,
                    ValidateIssuerSigningKey    = true,
                    ValidIssuer                 = Configuration["Jwt:Issuer"],
                    ValidAudience               = Configuration["Jwt:Issuer"],
                    IssuerSigningKey            = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
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
            
            // Add framework services.
            services.AddMvc(
                config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                    config.Filters.Add(new ValidateModelAttribute());
                }   
                )
                .AddFluentValidation(fv => 
                    {
                        fv.RegisterValidatorsFromAssemblyContaining<AddCategory>();
                        fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                    });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(
                provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);

            AddDbContext(services);

            ConfigureSwagger(services);

            MapInterfacesAndClasses(services);

            services.AddAutoMapper(typeof(Startup), typeof(BaseHandler));

            services.AddMediatR(typeof(Startup), typeof(BaseHandler), typeof(PasswordHashHandler));
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen((c) =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "ANABI", Version = "v1" });
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

        private void MapInterfacesAndClasses(IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddSingleton<IAnabiCrypt, AnabiCrypt>();
            services.AddTransient<BaseHandlerNeeds>();
            services.AddScoped<EmptyAddAddressValidator, EmptyAddAddressValidator>();
            services.AddScoped<AbstractValidator<IAddAddress>, AddAddressValidator>(); ;
            services.AddScoped<IDatabaseChecks, DatabaseChecks>();
            services.AddScoped<IAssetValidator, AssetValidator>();
            
        }

        private void AddDbContext(IServiceCollection services)
        {

            var connection = Configuration.GetConnectionString("AnabiDatabase");

            services.AddDbContext<AnabiContext>(options =>
            options.UseSqlServer(connection,
                         sqlServerOptionsAction: sqlOptions =>
                         {
                             sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,

                             maxRetryDelay: TimeSpan.FromSeconds(15),

                             errorNumbersToAdd: null);

                         }));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {

            app.UseAnabiExceptionResponse();

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseAuthentication();

            app.UseMvc();

            var context = app.ApplicationServices.GetService<AnabiContext>();
            DbInitializer.Initialize(context);

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
