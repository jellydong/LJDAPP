using System;
using Ly.Admin.Util.Enum;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Ly.Admin.Util.Cache
{
    /// <summary>
    /// 系统缓存
    /// </summary>
    public class SystemCache : ICache
    {
        private static IMemoryCache Cache { get; }
        static SystemCache()
        {
            var provider = new ServiceCollection().AddMemoryCache().BuildServiceProvider();
            Cache = provider.GetService<IMemoryCache>();
        }
        public void SetCache(string key, object value)
        {
            Cache.Set(key, value);
        }

        public void SetCache(string key, object value, TimeSpan timeout)
        {
            Cache.Set(key, value, new DateTimeOffset(DateTime.Now + timeout));
        }

        public void SetCache(string key, object value, TimeSpan timeout, ExpireTypeEnum expireType)
        {
            if (expireType == ExpireTypeEnum.Absolute)
            {
                //这里没转换标准时间，Linux时区会有问题？
                Cache.Set(key, value, new DateTimeOffset(DateTime.Now + timeout));
            }
            else
            {
                Cache.Set(key, value, timeout);
            }
        }

        public void SetKeyExpire(string key, TimeSpan expire)
        {
            var value = GetCache(key);
            SetCache(key, value, expire);
        }

        public object GetCache(string key)
        {
            return Cache.Get(key);
        }

        public T GetCache<T>(string key) where T : class
        {
            return (T)GetCache(key);
        }

        public bool ContainsKey(string key)
        {
            return Cache.TryGetValue(key, out object value);
        }

        public void RemoveCache(string key)
        {
            Cache.Remove(key);
        }
    }
}