using System;
using System.Linq;
using System.Linq.Expressions;
using LJD.App.Model.DbModels;
using LJD.App.Repository.IUnitOfWork;
using LJD.App.Service;
using LJD.App.Service.IService;
using LJD.App.Util;
using LJD.App.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LJD.App.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : BaseController
    {
        private readonly ISysRoleService _sysRoleService;
        private readonly ISysMenusService _sysMenusService;
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(ISysRoleService sysRoleService,ISysMenusService sysMenusService, IUnitOfWork unitOfWork)
        {
            _sysRoleService = sysRoleService;
            _sysMenusService = sysMenusService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string rName,string status,PagerInfo pagerInfo)
        {
            Expression<Func<SysRole, bool>> whereExpression = r => true;
            if (!string.IsNullOrEmpty(rName))
            {
                whereExpression = whereExpression.And(r => r.RName.Contains(rName));
            }
            if (!string.IsNullOrEmpty(status))
            {
                int state = Convert.ToInt32(status);
                whereExpression = whereExpression.And(r => r.Status.Equals(state));
            }

            var list = _sysRoleService.GetList(pagerInfo.PageIndex, pagerInfo.PageSize, out var count, whereExpression, true, r => r.Sort);

            return Json(BuildSuccessTableResult(count, list));
        }

        public IActionResult Form(string objectId)
        {
            //如果objectId不为空的话 需要则是编辑，获取信息否则新建一个
            var sysRole = string.IsNullOrEmpty(objectId) ? new SysRole() { Status = (int)Status.On } : _sysRoleService.GetList(r => r.ObjectID.Equals(objectId)).FirstOrDefault();

            return View(sysRole);
        }

        [HttpPost]
        public IActionResult Form(SysRole sysRole)
        {
            ResponseResult responseResult = new ResponseResult(success: false, message: "保存失败！");
            if (string.IsNullOrEmpty(sysRole.ObjectID))
            {
                sysRole.CreatedBy = CurrentUserManage.UserInfo.URealName;
                sysRole.CreatedTime = DateTime.Now;
                sysRole.Status = sysRole.Status == 0 ? 0 : 1;
                _sysRoleService.Create(sysRole);

                if (_unitOfWork.SaveChanges() == 1)
                {
                    responseResult.Success = true;
                    responseResult.Message = "保存成功！";
                }
            }
            else
            {
                var model = _sysRoleService.GetList(r => r.ObjectID.Equals(sysRole.ObjectID))
                    .FirstOrDefault();
                if (model != null)
                {

                    model.RName = sysRole.RName;
                    model.Remark = sysRole.Remark;
                    model.Sort = sysRole.Sort;
                    //后台设置项
                    model.Status = sysRole.Status == 0 ? 0 : 1;
                    model.ModifiedTime = DateTime.Now;
                    model.ModifiedBy = CurrentUserManage.UserInfo.URealName;
                    _sysRoleService.Edit(model);


                    if (_unitOfWork.SaveChanges() == 1)
                    {
                        responseResult.Success = true;
                        responseResult.Message = "保存成功！";
                    }
                }
                else
                {
                    responseResult.Message = "要修改的数据不存在！";
                }
            }

            return Json(responseResult);

        }

        [HttpPost]
        public IActionResult Delete(string ids)
        {
            var idsList = ids.ToList<string>();
            _sysRoleService.Delete(r => idsList.Contains(r.ObjectID));
            _unitOfWork.SaveChanges();
            return Json(new ResponseResult(true, "删除成功！"));

        }

        public IActionResult SetPermission(string roleObjectId,string rName)
        {
            ViewData["roleObjectId"] = roleObjectId;
            ViewData["rName"] = rName;
            //获取角色已有权限项ID
            ViewData["permissionList"] = PermissionManage.GetPermissionByRole(roleObjectId);
            //获取所有菜单   禁用的前端进行了控制
            var menus = _sysMenusService.GetList(m => true).Include("SysFunction").OrderBy(m => m.Hierarchy).ThenBy(m=>m.Sort).ToList();

            return View(menus);
        }
        /// <summary>
        /// 设置权限  怎加tag 是为区分，设置权限的时候好配置
        /// </summary>
        /// <param name="roleObjectId"></param>
        /// <param name="permissions"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SetPermission(string roleObjectId,string permissions,string tag)
        {
           var res= PermissionManage.SetPermissionWithRole(roleObjectId, permissions.ToList<string>());
            return Json(res);
        }
    }
}
