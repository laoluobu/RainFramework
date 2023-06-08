using Microsoft.Extensions.Caching.Memory;

namespace RainFramework.Cahce
{
    public class RFMemoryCache
    {
        private readonly IMemoryCache memoryCache;

        public RFMemoryCache(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationSeconds">绝对过期时间单位s</param>
        /// <param name="size"></param>
        public void Set<T>(object key, T value, int expirationSeconds, int size = 1)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSize(size);
            cacheEntryOptions.SetSize(1);
            cacheEntryOptions.SetAbsoluteExpiration(TimeSpan.FromSeconds(expirationSeconds));
            memoryCache.Set(key, value, cacheEntryOptions);
        }


        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationSeconds">绝对过期时间</param>
        /// <param name="size"></param>
        public void Set<T>(object key, T value, TimeSpan expiration, int size = 1)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSize(size);
            cacheEntryOptions.SetSize(1);
            cacheEntryOptions.SetAbsoluteExpiration(expiration);
            memoryCache.Set(key, value, cacheEntryOptions);
        }


        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>如果Key存在则返回True</returns>
        public bool TryGet<T>(object key, out T? value)
        {
            bool isFound = memoryCache.TryGetValue(key, out T? Value);
            value = Value;
            return isFound;
        }

        /// <summary>
        /// 删除缓存值
        /// </summary>
        /// <param name="key"></param>
        public void Remove(object key)
        {
            memoryCache.Remove(key);
        }
    }
}