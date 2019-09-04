using System;
using System.Collections.Generic;

namespace LJD.App.Model.DbModels
{
    public partial class R_UserPermissions
    {
        public string ObjectID { get; set; }
        public string UserID { get; set; }
        public string MenuID { get; set; }
        public string FunctionID { get; set; }
        public int? HavePermission { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual SysFunction Function { get; set; }
        public virtual SysMenus Menu { get; set; }
        public virtual SysUserInfo User { get; set; }
    }
}
