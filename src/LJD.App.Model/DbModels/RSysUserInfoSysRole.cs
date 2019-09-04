using System;
using System.Collections.Generic;

namespace LJD.App.Model.DbModels
{
    public partial class RSysUserInfoSysRole
    {
        public string ObjectId { get; set; }
        public string UserInfoId { get; set; }
        public string RoleId { get; set; }

        public virtual SysRole Role { get; set; }
        public virtual SysUserInfo UserInfo { get; set; }
    }
}
