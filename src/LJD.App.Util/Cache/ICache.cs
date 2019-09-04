using System; 

namespace LJD.App.Util
{
    /// <summary>
    /// 缓存操作接口类
    /// </summary>
    public interface ICache
    {
        #region 设置缓存 
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        /// <typeparam name="T">数据类型</typeparam>
        void SetCache(string key, object value);

        /// <summary>
        /// 设置缓存
        /// 注：默认过期类型为绝对过期
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        /// <param name="timeout">过期时间间隔</param>
        /// <typeparam name="T">数据类型</typeparam>
        void SetCache(string key, object value, TimeSpan timeout);

        /// <summary>
        /// 设置缓存
        /// 注：默认过期类型为绝对过期
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        /// <param name="timeout">过期时间间隔</param>
        /// <param name="expireType">过期类型</param>  
        void SetCache(string key, object value, TimeSpan timeout, ExpireType expireType);

        /// <summary>
        /// 设置键失效时间
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="expire">从现在起时间间隔</param>
        void SetKeyExpire(string key, TimeSpan expire);

        #endregion
        #region 获取缓存

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">主键</param>
        object GetCache(string key);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">主键</param>
        /// <typeparam name="T">数据类型</typeparam>
        T GetCache<T>(string key) where T : class;

        /// <summary>
        /// 是否存在键值
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        bool ContainsKey(string key);

        #endregion

        #region 删除缓存

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <param name="key">主键</param>
        void RemoveCache(string key);

        #endregion
    }
    /// <summary>
    /// 值信息
    /// 定义这样可以解决两个问题 1.存储的时候就知道存储的是什么类型  2.过期类型可以有操作不过期
    /// </summary>
    public struct ValueInfoEntry
    {
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 值的类型 比如 string  int
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public TimeSpan? ExpireTime { get; set; }
        /// <summary>
        /// 过期类型
        /// </summary>
        public ExpireType? ExpireType { get; set; }
    }
}