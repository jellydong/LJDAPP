using System.ComponentModel;

namespace Ly.Admin.Util.Enum
{
    public enum CacheTypeEnum
    {
        /// <summary>
        /// 系统缓存
        /// </summary>
        [Description("系统缓存")]
        SystemCache,

        /// <summary>
        /// Redis缓存
        /// </summary>
        [Description("Redis缓存")]
        RedisCache
    }
}