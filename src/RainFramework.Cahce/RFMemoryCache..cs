using Microsoft.Extensions.Caching.Memory;

namespace RainFramework.Cahce
{
    public class RFMemoryCache
    {
        private readonly IMemoryCache memoryCache;
      
        private readonly object hashSetLock = new object();

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
        public void Set<T>(object key, T value, TimeSpan? expiration, int size = 1)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSize(size);
            cacheEntryOptions.SetSize(1);
            if (expiration != null)
            {
                cacheEntryOptions.SetAbsoluteExpiration((TimeSpan)expiration);
            }     
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

        /// <summary>
        /// 创建或插入 hashSet cache，默认大小为10
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiration">整个列表的过期时间，每次修改都会重置</param>
        public void PushHashSet<T>(string key, T value, TimeSpan? expiration)
        {
            lock (hashSetLock)
            {
                var set = FindHashSet<T>(key);
                if (set != null)
                {
                    set.Add(value);
                    CreateHashSet(key, set, expiration);
                    return;
                }
                CreateHashSet(key, new HashSet<T> { value }, expiration);
            }
        }

        private void CreateHashSet<T>(string key, HashSet<T> set, TimeSpan? expiration)
        {
            Set(key + "HashSet", set, expiration, 10);
        }

        /// <summary>
        /// 从hashSet移除某个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void RemoveValueHashSet<T>(string key, T value)
        {
            lock (hashSetLock)
            {
                var set = FindHashSet<T>(key);
                set?.Remove(value);
            }
        }

        /// <summary>
        /// 判断hashSet是否包含某个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool ContainsHashSet<T>(string key, T value)
        {
            lock (hashSetLock)
            {
                var set = FindHashSet<T>(key);
                if (set == null)
                {
                    return false;
                }
                return set.Contains(value);
            }
        }

        /// <summary>
        /// 获取Hashset Cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public HashSet<T>? GetHashSet<T>(string key)
        {
            lock (hashSetLock)
            {
                return FindHashSet<T>(key);
            }
        }

        private HashSet<T>? FindHashSet<T>(string key)
        {
            bool isFound = memoryCache.TryGetValue(key + "HashSet", out HashSet<T>? hashSet);
            if (isFound)
            {
                return hashSet;
            }
            return null;
        }
    }
}