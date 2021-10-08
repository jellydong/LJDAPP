using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.Auth
{
    /// <summary>
    /// Claims名称 也可以用IdentityModel.JwtClaimTypes 
    /// 这里用自定义的
    /// </summary>
    public static class ClaimsName
    {
        /// <summary>
        /// 账户id
        /// </summary>
        public const string AccountId = "id";

        /// <summary>
        /// 账户名称
        /// </summary>
        public const string AccountName = "na";
         
        /// <summary>
        /// 账户类型
        /// </summary>
        public const string AccountType = "ty";

        /// <summary>
        /// 平台类型
        /// </summary>
        public const string Platform = "pf";

        /// <summary>
        /// 登录时间
        /// </summary>
        public const string LoginTime = "lt";
    }
}
