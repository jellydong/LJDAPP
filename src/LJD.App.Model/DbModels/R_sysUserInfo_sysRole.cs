using System;
using System.Collections.Generic;

namespace LJD.App.Model.DbModels
{
    public partial class R_sysUserInfo_sysRole
    {
        public string ObjectID { get; set; }
        public string UserInfoID { get; set; }
        public string RoleID { get; set; }

        public virtual SysRole Role { get; set; }
        public virtual SysUserInfo UserInfo { get; set; }
    }
}
