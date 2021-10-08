using Ly.Admin.Util.Enum;
using System.ComponentModel;

namespace Ly.Admin.Util.Configuration
{
    public class LyAdminOptionsRoot
    {
        public LyAdminOptions LyAdminOptions { get; set; }
    }
    public class LyAdminOptions
    {
        /// <summary>
        /// 项目名
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 运行模式
        /// </summary>
        public RunModelEnum RunModel { get; set; }

        /// <summary>
        /// 默认缓存 配置信息
        /// </summary>
        public LyAdminOptionsCacheType CacheType { get; set; }

        /// <summary>
        /// 用户登录超时分钟数
        /// </summary>
        public int LoginExpireMinutes { get; set; }

        /// <summary>
        /// 新增用户初始密码
        /// </summary>
        public string InitialPassword { get; set; }

        /// <summary>
        /// 默认缓存Key
        /// </summary>
        public LyAdminOptionsDefaultAPPKeys DefaultAppKeys { get; set; }
    }
    public class LyAdminOptionsCacheType
    {
        /// <summary>
        /// 缓存类型
        /// </summary>
        public CacheTypeEnum DefaultCache { get; set; }

        /// <summary>
        /// Redis链接字符串
        /// </summary>
        public string RedisConfig { get; set; }


    }

    // ReSharper disable once InconsistentNaming
    public class LyAdminOptionsDefaultAPPKeys
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { get; set; }

        /// <summary>
        /// 刷新令牌 
        /// <para>AUTH_REFRESH_TOKEN:刷新令牌</para>
        /// </summary> 
        public string AuthRefreshToken { get; set; }

        /// <summary>
        /// 认证信息
        /// <para>AUTH_INFO:账户编号:平台类型</para>
        /// </summary> 
        public string AuthInfo { get; set; }

        /// <summary>
        /// 当前用户
        /// </summary>
        public string CurrentUser { get; set; }

        /// <summary>
        /// 权限项缓存
        /// </summary>
        public string PermissionList { get; set; }


    }
}