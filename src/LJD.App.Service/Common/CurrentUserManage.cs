using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LJD.App.Model.DbModels;
using LJD.App.Model.ViewModels;
using LJD.App.Service.Service;
using LJD.App.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;

namespace LJD.App.Service
{
    /// <summary>
    /// 用户相关信息
    /// </summary>
    public static class CurrentUserManage
    {
        /// <summary>
        /// 当前登陆用户
        /// </summary>
        public static SysUserInfo UserInfo
        {
            get
            {
                //如果是测试模式 就直接是返回管理员就行
                if (GlobalSwitch.RunModel == RunModel.LocalTest)
                {
                    SysUserInfo userInfo =
                        new MySqlHelper().QueryEntity<SysUserInfo>(
                            "SELECT * FROM SysUserInfo WHERE ULoginName='admin'", CommandType.Text);
                    return userInfo;
                }
                else
                {
                    //获取客户端Cookies
                    var userLoginId = HttpContextCore.Current.Request.Cookies[APPKeys.CurrentUser];
                    //如果客户端Cookies不为null
                    if (!string.IsNullOrEmpty(userLoginId))
                    {
                        return CacheHelper.Cache.GetCache<SysUserInfo>(userLoginId);
                    }

                    return null;
                }
            }
        }
        /// <summary>
        /// 当前用户的权限
        /// </summary>
        public static List<RolePermissionForUser> UserPermissionList => PermissionManage.CurrentUserPermissionList;

         /// <summary>
         /// 递归获取用户权限菜单
         /// </summary>
        public static List<AdminLteMenu> UserPermissionMenu
        {
            get
            {
                int on = (int) Status.On;
                var permissionMenu = UserPermissionList.Where(m=>m.IsMenuShow.Equals(on)).Select(m => new AdminMenu()
                {
                    MObjectID = m.MObjectID,
                    MName = m.MName,
                    MArea = m.MArea,
                    MController = m.MController,
                    MIcon = m.MIcon,
                    IsLast = m.IsLast,
                    MHierarchy = m.MHierarchy,
                    MParentID = m.MParentID,
                    MStatus = m.MStatus, 
                    MSort = m.MSort
                }).Distinct(new AdminMenuComparer()).OrderBy(m => m.MHierarchy).ThenBy(m => m.MSort).ToList();

                List<AdminLteMenu> adminLteMenuList = new List<AdminLteMenu>()
                {
                    new AdminLteMenu()
                    {
                        Id= "9000",
                        Text= "LAJAPP菜单",
                        Icon= "",
                        IsHeader= true
                    }
                };




                //先循环第一层的
                foreach (var menu in permissionMenu.Where(m => m.MParentID.Equals("0")))
                {
                    //如果没有子菜单了
                    if (permissionMenu.Count(m => m.MParentID.Equals(menu.MObjectID)).Equals(0))
                    {
                        AdminLteMenu adminLteMenuChild = new AdminLteMenu()
                        {
                            Id = menu.MObjectID,
                            Text = menu.MName,
                            Icon = menu.MIcon,
                            Url = $"/{menu.MArea}/{menu.MController}/Index",
                            TargetType = "iframe-tab"
                        };
                        adminLteMenuList.Add(adminLteMenuChild);
                    }
                    else
                    {
                        AdminLteMenu adminLteMenuChild = new AdminLteMenu()
                        {
                            Id = menu.MObjectID,
                            Text = menu.MName,
                            Icon = menu.MIcon 
                        };
                        adminLteMenuChild.Children =
                            BuildMenu(permissionMenu, new List<AdminLteMenu>(), adminLteMenuChild);
                        adminLteMenuList.Add(adminLteMenuChild);
                    }
                }  
                return adminLteMenuList;
            }
        }

        private static List<AdminLteMenu> BuildMenu(List<AdminMenu> permissionMenu, List<AdminLteMenu> adminLteMenuChildList, AdminLteMenu adminMenu)
        { 
            //permissionMenu = permissionMenu.OrderBy(m => m.MHierarchy).ThenBy(m => m.MSort).ToList();
            foreach (var menu in permissionMenu.Where(m => m.MParentID.Equals(adminMenu.Id)))
            {
                //如果没有子菜单了
                if (permissionMenu.Count(m => m.MParentID.Equals(menu.MObjectID)).Equals(0))
                {
                    AdminLteMenu adminLteMenuChild = new AdminLteMenu()
                    {
                        Id = menu.MObjectID,
                        Text = menu.MName,
                        Icon = menu.MIcon,
                        Url = $"/{menu.MArea}/{menu.MController}/Index",
                        TargetType = "iframe-tab"
                    };
                    adminLteMenuChildList.Add(adminLteMenuChild);
                }
                else
                {
                    AdminLteMenu adminLteMenuChild = new AdminLteMenu()
                    {
                        Id = menu.MObjectID,
                        Text = menu.MName,
                        Icon = menu.MIcon
                    };
                    adminLteMenuChild.Children =
                        BuildMenu(permissionMenu, new List<AdminLteMenu>(),adminLteMenuChild);
                    adminLteMenuChildList.Add(adminLteMenuChild);
                }
            }

            return adminLteMenuChildList;
        }


        /// <summary>
        /// 是否已登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            return UserInfo != null;
        }
         


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userInfo"></param>
        public static void Login(SysUserInfo userInfo)
        {
            string userLoginId = Guid.NewGuid().ToString();
            //往客户端写入Cookie
            HttpContextCore.Current.Response.Cookies.Append(APPKeys.CurrentUser, userLoginId, new CookieOptions() { HttpOnly = true });
            HttpContextCore.Current.Response.Cookies.Append("text","12345", new CookieOptions { Expires = DateTime.MaxValue, HttpOnly = true });
            //把登陆用户保存到缓存中
            CacheHelper.Cache.SetCache(userLoginId, userInfo,TimeSpan.FromMinutes(GlobalSwitch.LoginExpireMinutes),ExpireType.Relative);
        }

        /// <summary>
        /// 注销
        /// </summary>
        public static void Logout()
        {

            if (GlobalSwitch.RunModel!=RunModel.LocalTest)
            {
                //获取客户端Cookies
                var userLoginId = HttpContextCore.Current.Request.Cookies[APPKeys.CurrentUser];
                //清空缓存
                CacheHelper.Cache.RemoveCache(userLoginId);
                //清空客户端Cookies
                HttpContextCore.Current.Response.Cookies.Delete(APPKeys.CurrentUser); 
            }
 
        }

    }
}
