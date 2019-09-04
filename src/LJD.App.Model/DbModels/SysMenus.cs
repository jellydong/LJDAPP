using System;
using System.Collections.Generic;

namespace LJD.App.Model.DbModels
{
    public partial class SysMenus
    {
        public SysMenus()
        {
            R_RolePermission = new HashSet<R_RolePermission>();
            R_UserPermissions = new HashSet<R_UserPermissions>();
            SysFunction = new HashSet<SysFunction>();
        }

        public string ObjectID { get; set; }
        public string MName { get; set; }
        public string MArea { get; set; }
        public string MController { get; set; }
        public string MIcon { get; set; }
        public int? IsLast { get; set; }
        public int? IsMenuShow { get; set; }
        public int Hierarchy { get; set; }
        public string Remark { get; set; }
        public string ParentID { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Sort { get; set; }

        public virtual ICollection<R_RolePermission> R_RolePermission { get; set; }
        public virtual ICollection<R_UserPermissions> R_UserPermissions { get; set; }
        public virtual ICollection<SysFunction> SysFunction { get; set; }
    }
}
