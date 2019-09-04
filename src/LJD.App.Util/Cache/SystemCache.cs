using System; 
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace LJD.App.Util
{
    public class SystemCache:ICache
    {
        static SystemCache()
        {
            var provider = new ServiceCollection().AddMemoryCache().BuildServiceProvider();
            Cache = provider.GetService<IMemoryCache>();
        }
        private static IMemoryCache Cache { get; }
        public void SetCache(string key, object value)
        {
            Cache.Set(key, value);
        }

        public void SetCache(string key, object value, TimeSpan timeout)
        {
            Cache.Set(key, value, new DateTimeOffset(DateTime.Now+ timeout));
        }

        public void SetCache(string key, object value, TimeSpan timeout, ExpireType expireType)
        {
            if (expireType==ExpireType.Absolute)
            {
                //这里没转换标准时间，Linux时区会有问题？
                Cache.Set(key, value, new DateTimeOffset(DateTime.Now+timeout));
            }
            else
            {
                Cache.Set(key, value, timeout);
            }
        } 

        public void SetKeyExpire(string key, TimeSpan expire)
        {
            var value = GetCache(key);
            SetCache(key,value,expire);
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