using System;
using System.Collections.Generic;
using System.Text;

namespace Ly.Admin.Resources
{
    public class LoginResultModel
    {
        /// <summary>
        /// 账户信息
        /// </summary>
        public UserInfoResource UserInfo { get; set; }

        /// <summary>
        /// 认证信息
        /// </summary>
        public AuthResource AuthResource { get; set; }
        

        //todo 权限列表要不要放到这里？
    }
}
