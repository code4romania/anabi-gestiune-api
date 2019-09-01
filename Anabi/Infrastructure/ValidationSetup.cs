using Anabi.Domain.Common;
using Anabi.Domain.Common.Address;
using Anabi.Middleware;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Anabi.Infrastructure
{
    public static class ValidationSetup
    {
        public static void AddAnabiValidationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddScoped<EmptyAddAddressValidator, EmptyAddAddressValidator>();
            services.AddScoped<AbstractValidator<IAddAddress>, AddAddressValidator>(); ;
            services.AddScoped<IDatabaseChecks, DatabaseChecks>();
            services.AddScoped<AbstractValidator<IAddMinimalAddress>, AddMinimalAddressValidator>();
        }
    }
}
