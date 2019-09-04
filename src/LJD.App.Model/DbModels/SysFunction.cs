using System;
using System.Collections.Generic;

namespace LJD.App.Model.DbModels
{
    public partial class SysFunction
    {
        public SysFunction()
        {
            R_RolePermission = new HashSet<R_RolePermission>();
            R_UserPermissions = new HashSet<R_UserPermissions>();
        }

        public string ObjectID { get; set; }
        public string FName { get; set; }
        public string FFunction { get; set; }
        public string FURL { get; set; }
        public string FIcon { get; set; }
        public string ParentID { get; set; }
        public string Remark { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Sort { get; set; }

        public virtual SysMenus Parent { get; set; }
        public virtual ICollection<R_RolePermission> R_RolePermission { get; set; }
        public virtual ICollection<R_UserPermissions> R_UserPermissions { get; set; }
    }
}
