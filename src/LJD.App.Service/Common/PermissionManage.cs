using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LJD.App.Model.DbModels;
using LJD.App.Model.ViewModels;
using LJD.App.Repository.IRepository;
using LJD.App.Repository.IUnitOfWork;
using LJD.App.Util;

namespace LJD.App.Service
{
    public static class PermissionManage
    {
        private static readonly IR_RolePermissionRepository RolePermissionRepository = AutofacHelper.GetService<IR_RolePermissionRepository>();
        private static readonly IR_UserPermissionsRepository UserPermissionsRepository = AutofacHelper.GetService<IR_UserPermissionsRepository>();
        private static readonly ISysUserInfoRepository SysUserInfoRepository = AutofacHelper.GetService<ISysUserInfoRepository>();
        private static readonly IUnitOfWork UnitOfWork = AutofacHelper.GetService<IUnitOfWork>();
        private static readonly MySqlHelper SqlHelper = new MySqlHelper();


        /// <summary>
        /// 当前登陆用户权限
        /// </summary>
        public static List<RolePermissionForUser> CurrentUserPermissionList
        {
            get
            {
                //判断是不是登录了
                if (!CurrentUserManage.IsLogin())
                {
                    //没登陆返回空集合
                    return new List<RolePermissionForUser>();
                }
                //登录 获取到当前登录用户 缓存的权限
                List<RolePermissionForUser> permissions = CacheHelper.Cache.GetCache<List<RolePermissionForUser>>(CurrentUserManage.UserInfo.ObjectID);
                //判断有没有缓存权限，有的话直接返回 没有则重新缓存一下 并返回
                //todo：没有的情况是管理员重新设置权限后所有用户权限全部清空
                return permissions ?? StorePermissionForUser(CurrentUserManage.UserInfo.ObjectID);
            }
        }

        /// <summary>
        /// 根据用户ID获取并存储权限列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>返回权限列表</returns>
        public static List<RolePermissionForUser> StorePermissionForUser(string userId)
        {
            //根据用户的Id获取权限
            string strsql =
                $@"SELECT ifnull(b.ObjectID,'')MObjectID,ifnull(FURL,'')FURL,
ifnull(b.MName,'')MName,  ifnull(b.MArea,'')MArea, ifnull(b.MController,'')MController, ifnull(b.MIcon,'')MIcon, ifnull(b.IsLast,0)IsLast, ifnull(b.IsMenuShow,0)IsMenuShow, ifnull(b.Hierarchy,'')MHierarchy, ifnull(b.ParentID,'')MParentID, ifnull(b.Status,0)MStatus,ifnull(b.Sort,0)MSort ,
ifnull(c.FName,'')FName,ifnull(c.FFunction,'')FFunction, ifnull(c.FIcon,'')FIcon, ifnull(c.Status,0)FStatus,ifnull(c.Sort,0)FSort
                FROM R_RolePermission a
            INNER JOIN SysMenus b ON a.MenuID = b.ObjectID
            LEFT JOIN SysFunction c ON a.FunctionID = c.ObjectID
            WHERE EXISTS(SELECT ObjectID FROM R_sysUserInfo_sysRole WHERE UserInfoID= '{userId}' AND RoleID = a.RoleID)
            ORDER BY b.Hierarchy,b.Sort";
            var permissionList = SqlHelper.GetListBySql<RolePermissionForUser>(strsql, CommandType.Text);

            //将当前用户的权限存到缓存中去
            CacheHelper.Cache.SetCache(userId, permissionList);
            return permissionList;
        }

        /// <summary>
        /// 清除所有用户权限缓存
        /// </summary>
        public static void ClearAllUserPermissionCache()
        {
            var userIdList = SysUserInfoRepository.GetList(u=>true).Select(u=>u.ObjectID).ToList();
            userIdList.ForEach(userid =>
            {
                CacheHelper.Cache.RemoveCache(userid);
            });
        }



        /// <summary>
        /// 设置角色权限
        /// </summary>
        /// <param name="roleObjectId">角色Id</param>
        /// <param name="permissions">权限</param>
        /// <returns></returns>
        public static ResponseResult SetPermissionWithRole(string roleObjectId, List<string> permissions)
        {
            ResponseResult responseResult = new ResponseResult(false);

            try
            {
                //需不需要验证角色或者权限项等存不存在呢？

                //1.先删除该角色下的所有权限
                RolePermissionRepository.Delete(r => r.RoleID.Equals(roleObjectId));
                //2.循环permissions 
                foreach (string permission in permissions)
                {
                    //3.分割 permission 是按指定格式传过来，可以保证是正确的。
                    string[] perStrings = permission.Split('=');
                    string menuId = perStrings[0];
                    string funcId = perStrings[1];

                    R_RolePermission rolePermission = new R_RolePermission()
                    {
                        RoleID = roleObjectId,
                        MenuID = menuId,
                        FunctionID = funcId,
                        CreatedBy = CurrentUserManage.UserInfo.URealName,
                        CreatedTime = DateTime.Now
                    };

                    RolePermissionRepository.Create(rolePermission);
                }

                responseResult.Message = "保存成功!";
                responseResult.Success = true;
                UnitOfWork.SaveChanges();
                //todo: 3.清除拥有该角色用户的权限缓存
                ClearAllUserPermissionCache();
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
                throw;
            }
            return responseResult;
        }

        /// <summary>
        /// 通过角色ID获取角色权限项及菜单ID
        /// </summary>
        /// <param name="roleObjectId">角色ID</param>
        /// <returns></returns>
        public static List<string> GetPermissionByRole(string roleObjectId)
        {
            var data = RolePermissionRepository.GetList(r => r.RoleID.Equals(roleObjectId)).Select(r => r.FunctionID).ToList();
            return data;
        }

    }
}