using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;

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
        /// <param name="expiration">整个列表的过期时间，每次修改都会重置,null 则不会失效</param>
        public void PushValueToHashSet<T>(string key, T value, TimeSpan? expiration)
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

        /// <summary>
        /// 从hashSet移除某个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void RemoveValueFromHashSet<T>(string key, T value)
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
                return FindHashSet<T>(key + "HashSet");
            }
        }


        /// <summary>
        /// 加入Queue或者创建Queue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="item"></param>
        /// <param name="expiration"></param>
        public void Enqueue<T>(string key, T item, TimeSpan? expiration)
        {
            var queue = FindQueue<T>(key);
            if (queue != null)
            {
                queue.Enqueue(item);
                Set(key, queue, expiration);
            }
            else
            {
                var newQueue = new ConcurrentQueue<T>();
                newQueue.Enqueue(item);
                CreateQueue(key, newQueue, expiration);
            }
        }

        public T? Dequeue<T>(string key)
        {
            var queue = FindQueue<T>(key);
            if(queue?.TryDequeue(out var value) ?? false)
            {
                return value;
            }
            return default;
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

        public ConcurrentQueue<T>? FindQueue<T>(string key)
        {
            bool isFound = memoryCache.TryGetValue(key + "Queue", out ConcurrentQueue<T>? queue);
            if (isFound)
            {
                return queue;
            }
            return null;
        }

        private void CreateHashSet<T>(string key, HashSet<T> set, TimeSpan? expiration)
        {
            Set(key + "HashSet", set, expiration, 10);
        }

        private void CreateQueue<T>(string key, ConcurrentQueue<T> queue, TimeSpan? expiration)
        {
            Set(key + "Queue", queue, expiration, 10);
        }

    }
}