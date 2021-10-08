using System.ComponentModel.DataAnnotations.Schema;
using Ly.Admin.Util.Enum;
using Microsoft.EntityFrameworkCore;

namespace Ly.Admin.Model
{
    [Table("sys_r_user_menu")]
    [Comment("用户菜单对应关系")]
    public class SysRUserMenu : Entity
    {

        /// <summary>
        /// 用户Id
        /// </summary>
        [Column("user_id", TypeName = "int(11)")]
        [Comment("用户Id")]
        public int UserId { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        [Column("menu_id", TypeName = "int(11)")]
        [Comment("菜单Id")]
        public int MenuId { get; set; }

        /// <summary>
        /// 是否拥有权限
        /// </summary>
        [Column("have_permission", TypeName = "int(1)")]
        [Comment("是否拥有权限")]
        public IsEnum HavePermission { get; set; }
    }
}