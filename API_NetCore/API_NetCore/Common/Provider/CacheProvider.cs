using Microsoft.Extensions.Caching.Memory;
using System;

namespace API_NetCore.Common.Provider
{
    public class CacheProvider
    {
        private readonly IMemoryCache _cache;
        public CacheProvider(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public object Get(string key)
        {
            _cache.TryGetValue(key, out var result);
            return result;
        }
        public object Set(string key, object value)
        {
            return _cache.Set(key, value);
        }
        public object Set(string key, object value, DateTimeOffset absoluteExpiration)
        {
            return _cache.Set(key, value, absoluteExpiration);
        }
        public void Delete(string key)
        {
            _cache.Remove(key);
        }

    }
}
