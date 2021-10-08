using Ly.Admin.Util.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ly.Admin.Resources
{
    public class AuthResource : BaseResource
    {

        /// <summary>
        /// 用户ID
        /// </summary>  
        public int UserId { get; set; }

        /// <summary>
        /// 登录平台
        /// </summary> 
        public PlatformEnum Platform { get; set; }

        /// <summary>
        /// 刷新令牌
        /// </summary> 
        public string RefreshToken { get; set; }

        /// <summary>
        /// 刷新令牌过期时间
        /// </summary> 
        public DateTime RefreshTokenExpiredTime { get; set; }

        /// <summary>
        /// 最后登录时间戳
        /// </summary> 
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary> 
        public string LoginIP { get; set; } = string.Empty;
    }
}
