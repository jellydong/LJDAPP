  
namespace LJD.App.Util
{
    public class GlobalSwitch
    {
        static GlobalSwitch()
        { 
        }

        /// <summary>
        /// 项目名
        /// </summary>
        public static string ProjectName { get; } = "LJD.App";
         
        /// <summary>
        /// 运行模式
        /// </summary>
        public static RunModel RunModel { get; } = RunModel.LocalTest;

        #region 缓存

        /// <summary>
        /// 默认缓存
        /// </summary>
        public static CacheType CacheType { get; } = CacheType.SystemCache;

        /// <summary>
        /// Redis配置字符串
        /// </summary>
        public static string RedisConfig { get; } = null /*"localhost:6379"*/;

        /// <summary>
        /// 菜单最大层级，暂时设置为3级
        /// </summary>
        public static int MenuMaxHierarchy { get; } = 3;

        /// <summary>
        /// 用户登录超时分钟数
        /// </summary>
        public static int LoginExpireMinutes { get; } = 30;

        /// <summary>
        /// 新增用户初始密码
        /// </summary>
        public static string InitialPassword { get; } = "000000";


        #endregion


    }
    /// <summary>
    /// 默认缓存类型
    /// </summary>
    public enum CacheType
    {
        /// <summary>
        /// 系统缓存
        /// </summary>
        SystemCache,

        /// <summary>
        /// Redis缓存
        /// </summary>
        RedisCache
    }
}