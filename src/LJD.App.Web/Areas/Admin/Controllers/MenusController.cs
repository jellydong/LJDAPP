using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LJD.App.Model.DbModels;
using LJD.App.Repository.IUnitOfWork;
using LJD.App.Service;
using LJD.App.Service.IService;
using LJD.App.Util; 
using LJD.App.Web.Controllers;
using Microsoft.AspNetCore.Mvc; 

namespace LJD.App.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenusController : BaseController
    {
        private readonly ISysMenusService _sysMenusService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISysFunctionService _sysFunctionService;

        public MenusController(ISysMenusService sysMenusService, IUnitOfWork unitOfWork, ISysFunctionService sysFunctionService)
        {
            _sysMenusService = sysMenusService;
            _unitOfWork = unitOfWork;
            _sysFunctionService = sysFunctionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string status,string isLast, string isMenuShow, PagerInfo pagerInfo)
        {
            Expression<Func<SysMenus,bool>> whereExpression = m=>true;
            if (!string.IsNullOrEmpty(status))
            {
                int state = Convert.ToInt32(status);
                whereExpression = whereExpression.And(m => m.Status.Equals(state));
            }
            if (!string.IsNullOrEmpty(isLast))
            {
                int last = Convert.ToInt32(isLast);
                whereExpression = whereExpression.And(m => m.IsLast.Equals(last));
            }
            if (!string.IsNullOrEmpty(isMenuShow))
            {
                int menuShow = Convert.ToInt32(isMenuShow);
                whereExpression = whereExpression.And(m => m.IsMenuShow.Equals(menuShow));
            }

            var lists = _sysMenusService.GetList(whereExpression).OrderBy(m => m.Hierarchy).ThenBy(m=>m.Sort).ToList();

            return Json(BuildSuccessTableResult(lists.Count, lists));
        }

        public IActionResult Form(string objectId, string parentId = "0")
        { 
            //如果objectId不为空的话则是编辑，获取信息否则新建一个
            var sysMenus = string.IsNullOrEmpty(objectId) ? new SysMenus() { Status = (int)Status.On, ParentID = parentId, IsLast = parentId.Equals("0") ? (int)Status.Off : (int)Status.On,IsMenuShow = (int)Status.On } : _sysMenusService.GetList(m => m.ObjectID.Equals(objectId)).FirstOrDefault();

            return View(sysMenus);
        }

        [HttpPost]
        public IActionResult Form(SysMenus sysMenus)
        {
            ResponseResult responseResult = new ResponseResult(success: false, message: "保存失败！");
            try
            { 

                if (string.IsNullOrEmpty(sysMenus.ObjectID))
                {
                    #region 层级获取判断

                    int hierarchy = 1;
                    if (!sysMenus.ParentID.Equals("0"))
                    {
                        //搜索父节点的层级
                        int on = (int) Status.On;
                        var parentHierarchy = _sysMenusService.GetList(m => m.ObjectID.Equals(sysMenus.ParentID) && m.Status.Equals(on)).Select(m => m.Hierarchy).FirstOrDefault();
                        hierarchy = (int)(parentHierarchy + 1);
                    }
                    //判断当前层级是不是超过了最大层级限制
                    if (hierarchy > GlobalSwitch.MenuMaxHierarchy)
                    {
                        throw new Exception($"当前菜单已经超过系统设定菜单最大层级【{GlobalSwitch.MenuMaxHierarchy}】层，如需要继续添加请修改系统配置！");
                    } 
                    #endregion

                    sysMenus.ObjectID = Guid.NewGuid().ToString();
                    sysMenus.CreatedBy = CurrentUserManage.UserInfo.URealName;
                    sysMenus.CreatedTime = DateTime.Now;
                    sysMenus.IsLast = sysMenus.IsLast == 0 ? 0 : 1;
                    sysMenus.IsMenuShow = sysMenus.IsMenuShow == 0 ? 0 : 1;
                    sysMenus.Status = sysMenus.Status == 0 ? 0 : 1;
                    sysMenus.Hierarchy = hierarchy;
                    //末级菜单 默认创建 查询和管理权限项
                    if (sysMenus.IsLast == 0)
                    {
                        sysMenus.SysFunction = BuildFunctions(sysMenus.ObjectID,sysMenus.MArea,sysMenus.MController);
                    }
                    _sysMenusService.Create(sysMenus);
                    _unitOfWork.SaveChanges();
                    responseResult.Success = true;
                    responseResult.Message = "保存成功！";

                }
                else
                {
                    var model = _sysMenusService.GetList(m => m.ObjectID.Equals(sysMenus.ObjectID))
                        .FirstOrDefault();
                    if (model != null)
                    {

                        model.MName = sysMenus.MName; 
                        model.MArea = sysMenus.MArea;
                        model.MController = sysMenus.MController; 
                        model.MIcon = sysMenus.MIcon;
                        model.IsLast = sysMenus.IsLast == 0 ? 0 : 1;
                        model.IsMenuShow = sysMenus.IsMenuShow == 0 ? 0 : 1;
                        model.Remark = sysMenus.Remark;
                        model.ParentID = sysMenus.ParentID;
                        model.Sort = sysMenus.Sort;
                        //后台设置项
                        model.Status = sysMenus.Status == 0 ? 0 : 1;
                        model.ModifiedTime = DateTime.Now;
                        model.ModifiedBy = CurrentUserManage.UserInfo.URealName;
                        _sysMenusService.Edit(model);

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
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult);

        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var result = _sysMenusService.Delete(id);
            return Json(result); 
        }
        #region 数据模型
        /// <summary>
        /// 创建末级菜单的时候，默认创建查询和管理两个权限项
        /// </summary>
        /// <param name="menuId">菜单ID</param>
        /// <returns></returns>
        public List<SysFunction> BuildFunctions(string menuId,string mArea,string mController)
        {
            return new List<SysFunction>()
            {
                new SysFunction()
                {
                    CreatedBy = CurrentUserManage.UserInfo.URealName,
                    CreatedTime = DateTime.Now,
                    FFunction = "Index",
                    FURL = $"/{mArea}/{mController}/Index",
                    FIcon = "fa fa-eye",
                    FName = "查看",
                    ParentID = menuId,
                    Remark = "查看权限",
                    Status = (int)Status.On,
                    Sort = 10
                },
                new SysFunction()
                {
                    CreatedBy = CurrentUserManage.UserInfo.URealName,
                    CreatedTime = DateTime.Now,
                    FFunction = "List",
                    FURL = $"/{mArea}/{mController}/List",
                    FIcon = "layui-icon layui-icon-search",
                    FName = "查询列表",
                    ParentID = menuId,
                    Remark = "查询列表",
                    Status = (int)Status.On,
                    Sort = 20
                },
                new SysFunction()
                {
                    CreatedBy = CurrentUserManage.UserInfo.URealName,
                    CreatedTime = DateTime.Now,
                    FFunction = "Form",
                    FURL = $"/{mArea}/{mController}/Form",
                    FIcon = "layui-icon layui-icon-search",
                    FName = "新增或编辑",
                    ParentID = menuId,
                    Remark = "新增或编辑",
                    Status = (int)Status.On,
                    Sort = 30
                },
                new SysFunction()
                {
                    CreatedBy = CurrentUserManage.UserInfo.URealName,
                    CreatedTime = DateTime.Now,
                    FFunction = "Delete",
                    FURL = $"/{mArea}/{mController}/Delete",
                    FIcon = "layui-icon layui-icon-delete",
                    FName = "删除",
                    ParentID = menuId,
                    Remark = "删除",
                    Status = (int)Status.On,
                    Sort = 40
                }
            };
        }


        #endregion

    }

}
