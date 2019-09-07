using Microsoft.Extensions.DependencyInjection;

namespace Anabi.Infrastructure
{
    public static class CacheSetup
    {
        public static void AddAnabiCachingServices(this IServiceCollection services)
        {
            services.AddSingleton<AnabiCacheManager>();
        }
    }
}
