using Ly.Admin.Util.Enum;
using System.Collections.Generic;

namespace Ly.Admin.Resources
{
    public class UserInfoResource : BaseResource
    {
        private List<UserRoleInfo> roleInfo = new List<UserRoleInfo>();

        /// <summary>
        /// 用户名
        /// </summary> 
        public string UserName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>  
        public string RealName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>  
        public string Avatar { get; set; }
        /// <summary>
        /// 性别
        /// </summary> 
        public Gender Gender { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>  
        public string Desc { get; set; }

        public List<UserRoleInfo> Roles { get => roleInfo; set => roleInfo = value; }
    }
    public class UserRoleInfo
    {
        public string RoleName { get; set; }
        public string Value { get; set; }

    }
}