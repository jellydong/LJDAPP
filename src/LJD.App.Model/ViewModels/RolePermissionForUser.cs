namespace LJD.App.Model.ViewModels
{
    /// <summary>
    /// 用于用户权限缓存
    /// </summary>
    public class RolePermissionForUser
    { 
        /// <summary>
        /// 菜单ID
        /// </summary>
        public string MObjectID { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MName { get; set; } 
        /// <summary>
        /// 菜单区域
        /// </summary>
        public string MArea { get; set; }
        /// <summary>
        /// 菜单控制器
        /// </summary>
        public string MController { get; set; } 
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string MIcon { get; set; }
        /// <summary>
        /// 菜单是否最后一项 0 是 1否
        /// </summary>
        public int IsLast { get; set; }
        /// <summary>
        ///是不是作为菜单显示:0-是;1-否
        /// </summary>
        public int IsMenuShow { get; set; }
        /// <summary>
        /// 层级
        /// </summary>
        public int MHierarchy { get; set; } 
        /// <summary>
        /// 菜单父ID
        /// </summary>
        public string MParentID { get; set; }
        /// <summary>
        /// 菜单状体 0 启用 1 禁用
        /// </summary>
        public int MStatus { get; set; } 
        /// <summary>
        /// 菜单排序值
        /// </summary>
        public int MSort { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 方法编码
        /// </summary>
        public string FFunction { get; set; }
        /// <summary>
        /// 方法图标
        /// </summary>
        public string FIcon { get; set; }
        /// <summary>
        /// 方法状态    
        /// </summary>
        public int FStatus { get; set; }
        /// <summary>
        /// 方法排序值
        /// </summary>
        public int FSort { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string FURL { get; set; }
    }
}