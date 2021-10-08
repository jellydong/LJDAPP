using System;
using Ly.Admin.Util.Configuration;
using Ly.Admin.Util.Enum; 

namespace Ly.Admin.Util.Cache
{
    public class CacheHelper
    {
        /// <summary>
        /// 静态构造函数，初始化缓存类型
        /// </summary>
        static CacheHelper()
        {
            SystemCache = new SystemCache();
            var cacheType = GlobalSettings.LyAdminOptions.CacheType.DefaultCache;
            var redisConfig = GlobalSettings.LyAdminOptions.CacheType.RedisConfig;

            //如果配置了RedisConfig的话，则使用Redis缓存
            if (!string.IsNullOrWhiteSpace(redisConfig))
            {
                try
                {
                    RedisCache = new RedisCache(redisConfig);
                }
                catch
                {

                }
            }

            //判断GlobalSwitch的缓存类型配置的是什么 设置默认缓存为GlobalSwitch配置的
            switch (cacheType)
            {
                case CacheTypeEnum.SystemCache:
                    Cache = SystemCache;
                    break;
                case CacheTypeEnum.RedisCache:
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