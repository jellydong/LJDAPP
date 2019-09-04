using System;
using System.Collections.Generic;

namespace LJD.App.Model.DbModels
{
    public partial class SysOrganizationUnit
    {
        public SysOrganizationUnit()
        {
            SysUserInfo = new HashSet<SysUserInfo>();
        }

        public string ObjectID { get; set; }
        public string OuParentID { get; set; }
        public string OuName { get; set; }
        public int? OuLevel { get; set; }
        public string Remark { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Sort { get; set; }

        public virtual ICollection<SysUserInfo> SysUserInfo { get; set; }
    }
}
