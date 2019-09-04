namespace LJD.App.Model.ViewModels
{
    public class AdminMenu
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
         
        public override string ToString()
        {
            return
                $"{{MObjectID={MObjectID},MName={MName},MArea={MArea},MController={MController},MIcon={MIcon},IsLast={IsLast},MHierarchy={MHierarchy},MParentID={MParentID},MStatus={MStatus},MSort={MSort}}}";
        }
    }
}