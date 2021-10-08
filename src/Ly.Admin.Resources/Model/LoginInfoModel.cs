using Ly.Admin.Util.Enum;

namespace Ly.Admin.Resources
{
    public class LoginInfoModel
    {
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public VerifyCodeModel VerifyCode { get; set; }

        public bool? Remember { get; set; }

        /// <summary>
        /// 登录平台
        /// </summary> 
        public PlatformEnum Platform { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary> 
        public string? IP { get; set; }
    }
}