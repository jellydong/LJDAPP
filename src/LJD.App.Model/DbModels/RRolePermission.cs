using System;
using System.Collections.Generic;

namespace LJD.App.Model.DbModels
{
    public partial class RRolePermission
    {
        public string ObjectId { get; set; }
        public string RoleId { get; set; }
        public string MenuId { get; set; }
        public string FunctionId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual SysFunction Function { get; set; }
        public virtual SysMenus Menu { get; set; }
        public virtual SysRole Role { get; set; }
    }
}
