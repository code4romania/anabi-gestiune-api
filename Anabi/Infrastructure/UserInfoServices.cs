using Anabi.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Principal;

namespace Anabi.Infrastructure
{
    public static class UserInfoServices
    {
        public static void AddAnabiUserInfoServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(
                provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
            services.AddTransient<BaseHandlerNeeds>();
        }
    }
}
