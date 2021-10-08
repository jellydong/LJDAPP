using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.Auth
{
    /// <summary>
    /// JWT令牌
    /// </summary>
    public class JwtTokenModel
    {
        /// <summary>
        /// jwt令牌
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// 有效期(秒)
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string RealName {  get; set; }
    }
}
