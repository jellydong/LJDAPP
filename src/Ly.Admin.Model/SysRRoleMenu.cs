using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ly.Admin.Model
{
    [Table("sys_r_role_menu")]
    [Comment("角色菜单对应关系")]
    public class SysRRoleMenu:Entity
    {  

        /// <summary>
        /// 角色Id
        /// </summary>
        [Column("role_id", TypeName = "int(11)")]
        [Comment("角色Id")]
        public int RoleId { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        [Column("menu_id", TypeName = "int(11)")]
        [Comment("菜单Id")]
        public int MenuId { get; set; }

    }
}