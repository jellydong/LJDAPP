using System;
using System.Collections.Generic;

namespace LJD.App.Model.DbModels
{
    public partial class SysUserInfo
    {
        public SysUserInfo()
        {
            R_UserPermissions = new HashSet<R_UserPermissions>();
            R_sysUserInfo_sysRole = new HashSet<R_sysUserInfo_sysRole>();
        }

        public string ObjectID { get; set; }
        public string ULoginName { get; set; }
        public string ULoginPWD { get; set; }
        public string URealName { get; set; }
        public string UTelphone { get; set; }
        public string UMobile { get; set; }
        public string UEmail { get; set; }
        public string UQQ { get; set; }
        public int? UGender { get; set; }
        public string UDepID { get; set; }
        public string Remark { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Sort { get; set; }

        public virtual SysOrganizationUnit UDep { get; set; }
        public virtual ICollection<R_UserPermissions> R_UserPermissions { get; set; }
        public virtual ICollection<R_sysUserInfo_sysRole> R_sysUserInfo_sysRole { get; set; }
    }
}
