using Anabi.Domain.Category.Commands;
using Anabi.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Anabi.Infrastructure
{
    public static class FrameworkServicesSetup
    {
        public static void AddAnabiFrameworkServices(this IServiceCollection services)
        {
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
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2); ;
        }
    }
}
