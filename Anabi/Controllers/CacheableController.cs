using System;
using System.Threading.Tasks;
using Anabi.Infrastructure;
using Microsoft.Extensions.Caching.Memory;

namespace Anabi.Controllers
{
    public class CacheableController : BaseController
    {
        protected readonly AnabiCacheManager _cache;

        public CacheableController(AnabiCacheManager cache)
        {
            _cache = cache;
        }

        protected async Task<T> GetOrSetFromCacheAsync<T>(string key, long size, Func<Task<T>> deleg, double expirationSeconds = 60*60*24)
        {
            if (!_cache.Cache.TryGetValue(key, out T result))
            {
                var x = await deleg.Invoke();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(expirationSeconds))
                    .SetSize(size);
                    

                _cache.Cache.Set(key, x, cacheEntryOptions);

                return x;
            }

            return result;
        }
    }
}
