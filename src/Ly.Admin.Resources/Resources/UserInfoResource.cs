using Ly.Admin.Util.Enum;

namespace Ly.Admin.Resources
{
    public class UserInfoResource:BaseResource
    {
        /// <summary>
        /// 用户名
        /// </summary> 
        public string UserName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>  
        public string RealName { get; set; } 
        /// <summary>
        /// 性别
        /// </summary> 
        public Gender Gender { get; set; }  
    }
}