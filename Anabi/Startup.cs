using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Anabi.DataAccess.Ef;
using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Swashbuckle.AspNetCore.Swagger;
using Serilog;
using System.IO;
using Anabi.Domain;
using Anabi.Domain.Category;
using Anabi.Domain.Category.Commands;
using Anabi.Domain.Decision;
using Anabi.Domain.Institution;
using Anabi.Domain.RecoveryBeneficiary;
using Anabi.Domain.Stage;
using Anabi.Domain.StorageSpaces;
using AutoMapper;
using MediatR;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace Anabi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "anabi-apilog-{Date}.txt"))
                .CreateLogger();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()
                .AddFluentValidation();
            
            

            AddDbContext(services);

            MapInterfacesAndClasses(services);

            services.AddAutoMapper(typeof(Startup), typeof(BaseHandler));

            services.AddMediatR(typeof(Startup), typeof(BaseHandler));
        }

        private void MapInterfacesAndClasses(IServiceCollection services)
        {
            services.AddScoped<AbstractValidator<AddCategory>, AddCategoryValidator>();
            services.AddScoped<AbstractValidator<EditCategory>, EditCategoryValidator>();
            services.AddScoped<AbstractValidator<DeleteCategory>, DeleteCategoryValidator>();

            services.AddScoped<IGenericRepository<DecisionDb>, DecisionsRepository>();
            services.AddScoped<IGenericRepository<InstitutionDb>, InstitutionsRepository>();
            services.AddScoped<IGenericRepository<StageDb>, StagesRepository>();
            services.AddScoped<IGenericRepository<StorageSpaceDb>, StorageSpacesRepository>();

            services.AddScoped<IGenericRepository<RecoveryBeneficiaryDb>, RecoveryBeneficiariesRepository>();

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

            services.AddSwaggerGen((c) => {
                c.SwaggerDoc("v1", new Info() { Title = "ANABI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddSerilog();

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            
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
