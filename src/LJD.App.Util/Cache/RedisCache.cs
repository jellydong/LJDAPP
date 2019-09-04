using System; 
using Newtonsoft.Json;
using StackExchange.Redis;

namespace LJD.App.Util
{
    public class RedisCache:ICache
    {
        /// <summary>
        /// 默认构造函数
        /// 注：使用默认配置，即localhost:6379,无密码
        /// </summary>
        public RedisCache()
        {
            DatabaseIndex = 0;
            string config = "localhost:6379";
            RedisConnection = ConnectionMultiplexer.Connect(config);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">配置字符串</param>
        /// <param name="databaseIndex">数据库索引</param>
        public RedisCache(string config, int databaseIndex = 0)
        {
            DatabaseIndex = databaseIndex;
            RedisConnection = ConnectionMultiplexer.Connect(config);
        }
        private ConnectionMultiplexer RedisConnection { get; }
        private IDatabase Db { get => RedisConnection.GetDatabase(DatabaseIndex); }
        private int DatabaseIndex { get; }


        #region 设置缓存

        public void SetCache(string key, object value)
        {
            _SetCache(key, value, null, null);
        }

        public void SetCache(string key, object value, TimeSpan timeout)
        {
            _SetCache(key, value, timeout, null);
        }

        public void SetCache(string key, object value, TimeSpan timeout, ExpireType expireType)
        {
           _SetCache(key,value,timeout,expireType);
        }
         
        public void SetKeyExpire(string key, TimeSpan expire)
        {
            Db.KeyExpire(key, expire);
        }

        public void _SetCache(string key, object value, TimeSpan? timeout, ExpireType? expireType)
        {
            #region 判断是不是字符串，如果不是则转成字符串，有利于存储

            string jsonStr = string.Empty;
            if (value is string)
            {
                jsonStr = value as string;
            }
            else
            {
                jsonStr = JsonConvert.SerializeObject(value);
            }  
            #endregion
            //创建一个值对象进行存储
            ValueInfoEntry entry=new ValueInfoEntry()
            {
                Value = jsonStr,
                TypeName = value.GetType().AssemblyQualifiedName,
                ExpireTime = timeout,
                ExpireType = expireType
            };
            string theValue = JsonConvert.SerializeObject(entry);
            if (timeout==null)
            {
                Db.StringSet(key, theValue);
            }
            else
            {
                Db.StringSet(key, theValue, timeout);
            }
        }

        #endregion
        #region 获取缓存
        public object GetCache(string key)
        {
            object value = null;
            //从Redis里获取当时存储的值  应该是 ValueInfoEntry 的JSON字符串
            var redisValue = Db.StringGet(key);
            //如果没有值的话  返回null
            if (!redisValue.HasValue)
            {
                return null;
            }
            //有值则转换为 ValueInfoEntry对象
            ValueInfoEntry valueInfoEntry = JsonConvert.DeserializeObject<ValueInfoEntry>(redisValue.ToString());
            if (valueInfoEntry.TypeName==typeof(string).AssemblyQualifiedName)
            {
                //如果是string类型的则直接返回
                value = valueInfoEntry.Value;
            }
            else
            {
                value = JsonConvert.DeserializeObject(valueInfoEntry.Value, Type.GetType(valueInfoEntry.TypeName));
            }
            //判断过期类型 如果是相对过期  则再次设置过期时间
            if (valueInfoEntry.ExpireTime != null&&valueInfoEntry.ExpireType==ExpireType.Relative)
            {
                SetKeyExpire(key,valueInfoEntry.ExpireTime.Value);
            }

            return value;
        }

        public T GetCache<T>(string key) where T : class
        {
            return (T) GetCache(key);
        }


        #endregion

        public bool ContainsKey(string key)
        {
            return Db.KeyExists(key);
        }
        public void RemoveCache(string key)
        {
            Db.KeyDelete(key);
        }
    }
}