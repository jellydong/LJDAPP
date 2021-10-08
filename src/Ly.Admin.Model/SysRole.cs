using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Ly.Admin.Util.Enum;
using Microsoft.EntityFrameworkCore;

namespace Ly.Admin.Model
{
    [Table("sys_role")]
    [Comment("角色表")]
    public class SysRole:Entity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("role_name", TypeName = "varchar(50)")]
        [Comment("角色名称")]
        public string RoleName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column("remark", TypeName = "varchar(200)")]
        [Comment("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Column("status", TypeName = "int(1)")]
        [Comment("状态")]
        public StatusEnum Status { get; set; }
    }
}