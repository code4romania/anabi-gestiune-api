using Microsoft.Extensions.Caching.Memory;
using System;

namespace Anabi.Infrastructure
{
    public class AnabiCacheManager
    {
        public MemoryCache Cache { get; set; }

        public AnabiCacheManager()
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 1024,
                CompactionPercentage = .33,
                ExpirationScanFrequency = TimeSpan.FromHours(3)
            });
        }
    }
}
