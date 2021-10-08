using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ly.Admin.Util.Enum;
using Microsoft.EntityFrameworkCore;

namespace Ly.Admin.Model
{
    [Table("sys_menu")]
    [Comment("菜单表")]
    public class SysMenu : Entity
    {
        /// <summary>
        /// 父级
        /// </summary>
        [Column("parent_id", TypeName = "int(11)")]
        [Comment("父级")]
        public int ParentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Column("menu_name", TypeName = "varchar(50)")]
        [Comment("菜单名称")]
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单链接
        /// </summary>
        [Column("menu_url", TypeName = "varchar(200)")]
        [Comment("菜单链接")]
        public string MenuUrl { get; set; }
        /// <summary>
        /// 权限码
        /// </summary>
        [Column("permission_code", TypeName = "varchar(500)")]
        [Comment("权限码")]
        public string PermissionCode { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        [Column("is_display", TypeName = "int(1)")]
        [Comment("是否显示")]
        public IsEnum IsDisplay { get; set; }
        /// <summary>
        /// 层级
        /// </summary>
        [Column("hierarchy", TypeName = "int(1)")]
        [Comment("层级")]
        public int Hierarchy { get; set; }
        /// <summary>
        /// 菜单类型
        /// </summary>
        [Column("menu_type", TypeName = "int(1)")]
        [Comment("菜单类型")]
        public MenuTypeEnum MenuType { get; set; }
        /// <summary>
        /// 打开方式
        /// </summary>
        [Column("open_type", TypeName = "int(1)")]
        [Comment("打开方式")]
        public MenuOpenTypeEnum OpenType { get; set; }
        /// <summary>
        /// 图标
        /// </summary>            
        [Column("menu_icon", TypeName = "varchar(50)")]
        [Comment("图标")]
        public string MenuIcon { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Column("status", TypeName = "int(1)")]
        [Comment("状态")]
        public StatusEnum Status { get; set; }  


    }
}