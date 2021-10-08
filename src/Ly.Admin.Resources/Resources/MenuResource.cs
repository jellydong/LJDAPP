using Ly.Admin.Util.Enum;

namespace Ly.Admin.Resources
{
    public class MenuResource: BaseResource
    {
        /// <summary>
        /// 父级
        /// </summary> 
        public int ParentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary> 
        public string Name { get; set; }
        /// <summary>
        /// 菜单链接
        /// </summary> 
        public string Url { get; set; }
        /// <summary>
        /// 权限码
        /// </summary> 
        public string PermissionCode { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary> 
        public IsEnum IsDisplay { get; set; }
        /// <summary>
        /// 层级
        /// </summary> 
        public int Hierarchy { get; set; }
        /// <summary>
        /// 菜单类型
        /// </summary> 
        public MenuTypeEnum MenuType { get; set; }
        /// <summary>
        /// 打开方式
        /// </summary> 
        public MenuOpenTypeEnum OpenType { get; set; }
        /// <summary>
        /// 图标
        /// </summary> 
        public string Icon { get; set; }

        /// <summary>
        /// 状态
        /// </summary> 
        public StatusEnum Status { get; set; }

    }
}