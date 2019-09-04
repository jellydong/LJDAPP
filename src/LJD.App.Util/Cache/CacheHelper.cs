using System;

namespace LJD.App.Util
{
    public class CacheHelper
    {
        /// <summary>
        /// 静态构造函数，初始化缓存类型
        /// </summary>
        static CacheHelper()
        {
            SystemCache = new SystemCache();
            //如果配置了RedisConfig的话，则使用Redis缓存
            if (!GlobalSwitch.RedisConfig.IsNullOrEmpty())
            {
                try
                {
                    RedisCache = new RedisCache(GlobalSwitch.RedisConfig);
                }
                catch
                {

                }
            }

            //判断GlobalSwitch的缓存类型配置的是什么 设置默认缓存为GlobalSwitch配置的
            switch (GlobalSwitch.CacheType)
            {
                case CacheType.SystemCache:
                    Cache = SystemCache;
                    break;
                case CacheType.RedisCache:
                    Cache = RedisCache;
                    break;
                default:
                    throw new Exception("请指定缓存类型！");
            }
        }
        /// <summary>
        /// 默认缓存
        /// </summary>
        public static ICache Cache { get; }

        /// <summary>
        /// 系统缓存
        /// </summary>
        public static ICache SystemCache { get; }

        /// <summary>
        /// Redis缓存
        /// </summary>
        public static ICache RedisCache { get; }
    }
}