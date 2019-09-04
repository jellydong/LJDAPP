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
    public class FunctionController : BaseController
    {
        private readonly ISysFunctionService _sysFunctionService;
        private readonly IUnitOfWork _unitOfWork;

        public FunctionController(ISysFunctionService sysFunctionService, IUnitOfWork unitOfWork)
        {
            _sysFunctionService = sysFunctionService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string objectId)
        {
            ViewData["parentId"] = objectId;
            return View();
        }

        public IActionResult List(string parentId,string fName,string status, PagerInfo pagerInfo)
        {
            Expression<Func<SysFunction, bool>> whereExpression = f => f.ParentID.Equals(parentId);
            if (!string.IsNullOrEmpty(fName))
            {
                whereExpression = whereExpression.And(f => f.FName.Contains(fName));
            }

            if (!string.IsNullOrEmpty(status))
            {
                int state = Convert.ToInt32(status);
                whereExpression = whereExpression.And(f => f.Status.Equals(state));
            }
            var list = _sysFunctionService.GetList(pagerInfo.PageIndex, pagerInfo.PageSize, out var count, whereExpression, true, f => f.Sort).ToList();

            return Json(BuildSuccessTableResult(count, list));
        }

        public IActionResult Form(string objectId,string parentId)
        { 
            //如果objectId不为空的话 需要则是编辑，获取信息否则新建一个
            var sysFunction = string.IsNullOrEmpty(objectId) ? new SysFunction() {ParentID = parentId ,Status = (int)Status.On} : _sysFunctionService.GetList( f => f.ObjectID.Equals(objectId)).FirstOrDefault();

            return View(sysFunction);
        }

        [HttpPost]
        public IActionResult Form(SysFunction sysFunction)
        {
            ResponseResult responseResult = new ResponseResult(success: false, message: "保存失败！");
            if (string.IsNullOrEmpty(sysFunction.ObjectID))
            {
                sysFunction.CreatedBy = CurrentUserManage.UserInfo.URealName;
                sysFunction.CreatedTime = DateTime.Now;
                sysFunction.Status = sysFunction.Status == 0 ? 0 : 1;
                _sysFunctionService.Create(sysFunction);

                if (_unitOfWork.SaveChanges() == 1)
                {
                    responseResult.Success = true;
                    responseResult.Message = "保存成功！";
                }
            }
            else
            {
                var model = _sysFunctionService.GetList(f => f.ObjectID.Equals(sysFunction.ObjectID))
                    .FirstOrDefault();
                if (model != null)
                {

                    model.FName = sysFunction.FName;
                    model.FFunction = sysFunction.FFunction;
                    model.FURL = sysFunction.FURL;
                    model.FIcon = sysFunction.FIcon; 
                    model.Remark = sysFunction.Remark;
                    model.Sort = sysFunction.Sort;
                    //后台设置项
                    model.Status = sysFunction.Status == 0 ? 0 : 1;
                    model.ModifiedTime = DateTime.Now;
                    model.ModifiedBy = CurrentUserManage.UserInfo.URealName;
                    _sysFunctionService.Edit(model);


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
            _sysFunctionService.Delete(f => idsList.Contains(f.ObjectID));
            _unitOfWork.SaveChanges();
            return Json(new ResponseResult(true, "删除成功！"));

        }
    }
}
