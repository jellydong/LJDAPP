using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ly.Admin.Model
{
    [Table("sys_r_user_role")]
    [Comment("用户角色对应关系")]
    public class SysRUserRole:Entity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Column("user_id", TypeName = "int(11)")]
        [Comment("用户Id")]
        public int UserId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [Column("role_id", TypeName = "int(11)")]
        [Comment("角色Id")]
        public int RoleId { get; set; }
    }
}