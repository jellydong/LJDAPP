using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.Resources
{
    public class VueRouterMetaResource
    { 
        /// <summary>
        /// 路由title  一般必填
        /// </summary>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// 动态路由可打开Tab页数
        /// </summary>
        [JsonProperty(PropertyName = "dynamicLevel", NullValueHandling = NullValueHandling.Ignore)]
        public int? DynamicLevel { get; set; }

        /// <summary>
        /// 动态路由的实际Path, 即去除路由的动态部分;
        /// </summary>
        [JsonProperty(PropertyName = "realPath", NullValueHandling = NullValueHandling.Ignore)]
        public string RealPath { get; set; }

        /// <summary>
        /// 是否忽略权限，只在权限模式为Role的时候有效
        /// </summary>
        [JsonProperty(PropertyName ="ignoreAuth",NullValueHandling =NullValueHandling.Ignore)]
        public bool? IgnoreAuth { get; set; }
         
        /// <summary>
        /// 是否忽略KeepAlive缓存
        /// </summary>
        [JsonProperty(PropertyName ="ignoreKeepAlive",NullValueHandling =NullValueHandling.Ignore)]
        public bool? ignoreKeepAlive { get; set; }
        /// <summary>
        /// 是否固定标签
        /// </summary>
        [JsonProperty(PropertyName ="affix",NullValueHandling =NullValueHandling.Ignore)]
        public bool? affix { get; set; }
        /// <summary>
        /// 图标，也是菜单图标
        /// </summary>
        [JsonProperty(PropertyName ="icon",NullValueHandling =NullValueHandling.Ignore)]
        public string? Icon { get; set; }
        /// <summary>
        /// 内嵌iframe的地址
        /// </summary>
        [JsonProperty(PropertyName ="frameSrc",NullValueHandling =NullValueHandling.Ignore)]
        public string? FrameSrc { get; set; }
        /// <summary>
        ///  指定该路由切换的动画名
        /// </summary>
        [JsonProperty(PropertyName ="transitionName",NullValueHandling =NullValueHandling.Ignore)]
        public string? transitionName { get; set; }
        /// <summary>
        /// 隐藏该路由在面包屑上面的显示
        /// </summary>
        [JsonProperty(PropertyName ="hideBreadcrumb",NullValueHandling =NullValueHandling.Ignore)]
        public bool? HideBreadcrumb { get; set; }
        /// <summary>
        /// 如果该路由会携带参数，且需要在tab页上面显示。则需要设置为true
        /// </summary>
        [JsonProperty(PropertyName ="carryParam",NullValueHandling =NullValueHandling.Ignore)]
        public bool? CarryParam { get; set; }
        /// <summary>
        /// 隐藏所有子菜单
        /// </summary>
        [JsonProperty(PropertyName ="hideChildrenInMenu",NullValueHandling =NullValueHandling.Ignore)]
        public bool? HideChildrenInMenu { get; set; }
        /// <summary>
        /// 当前激活的菜单。用于配置详情页时左侧激活的菜单路径
        /// </summary>
        [JsonProperty(PropertyName ="currentActiveMenu",NullValueHandling =NullValueHandling.Ignore)]
        public string? CurrentActiveMenu { get; set; }
        /// <summary>
        /// 当前路由不再标签页显示
        /// </summary>
        [JsonProperty(PropertyName ="hideTab",NullValueHandling =NullValueHandling.Ignore)]
        public bool? HideTab { get; set; }
        /// <summary>
        /// 当前路由不再菜单显示
        /// </summary>
        [JsonProperty(PropertyName ="hideMenu",NullValueHandling =NullValueHandling.Ignore)]
        public bool? HideMenu { get; set; }
        /// <summary>
        /// 菜单排序，只对第一级有效
        /// </summary>
        [JsonProperty(PropertyName ="orderNo",NullValueHandling =NullValueHandling.Ignore)]
        public int? OrderNo { get; set; }
        /// <summary>
        /// 忽略路由。用于在ROUTE_MAPPING以及BACK权限模式下，生成对应的菜单而忽略路由。2.5.3以上版本有效
        /// </summary>
        [JsonProperty(PropertyName ="ignoreRoute",NullValueHandling =NullValueHandling.Ignore)]
        public bool? IgnoreRoute { get; set; }
        /// <summary>
        /// 是否在子级菜单的完整path中忽略本级path。2.5.3以上版本有效
        /// </summary>
        [JsonProperty(PropertyName ="hidePathForChildren",NullValueHandling =NullValueHandling.Ignore)]
        public bool? HidePathForChildren { get; set; }

        #region 不需要提供

        // 可以访问的角色，只在权限模式为Role的时候有效
        //roles?: RoleEnum[]; 
        #endregion


    }
}
