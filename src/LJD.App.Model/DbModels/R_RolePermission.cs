using System;
using System.Collections.Generic;

namespace LJD.App.Model.DbModels
{
    public partial class R_RolePermission
    {
        public string ObjectID { get; set; }
        public string RoleID { get; set; }
        public string MenuID { get; set; }
        public string FunctionID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual SysFunction Function { get; set; }
        public virtual SysMenus Menu { get; set; }
        public virtual SysRole Role { get; set; }
    }
}
