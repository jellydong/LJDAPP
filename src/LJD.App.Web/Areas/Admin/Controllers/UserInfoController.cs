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
    public class UserInfoController : BaseController
    {
        private readonly ISysUserInfoService _sysUserInfoService;
        private readonly ISysRoleService _sysRoleService;
        private readonly IR_sysUserInfo_sysRoleService _sysUserInfoSysRoleService; 
        private readonly IUnitOfWork _unitOfWork;

        public UserInfoController(ISysUserInfoService sysUserInfoService,ISysRoleService sysRoleService,IR_sysUserInfo_sysRoleService sysUserInfoSysRoleService,IUnitOfWork unitOfWork)
        {
            _sysUserInfoService = sysUserInfoService;
            _sysRoleService = sysRoleService;
            _sysUserInfoSysRoleService = sysUserInfoSysRoleService; 
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string uloginName,string urealName,string ugender,string status,PagerInfo pagerInfo)
        {
            Expression<Func<SysUserInfo, bool>> whereExpression = u => true;
            if (!string.IsNullOrEmpty(uloginName))
            {
                whereExpression= whereExpression.And(u => u.ULoginName.Contains(uloginName));
            }
            if (!string.IsNullOrEmpty(urealName))
            {
                whereExpression = whereExpression.And(u => u.URealName.Contains(urealName));
            }
            if (!string.IsNullOrEmpty(ugender))
            {
                int gender = Convert.ToInt32(ugender);
                whereExpression = whereExpression.And(u => u.UGender.Equals(gender));
            }
            if (!string.IsNullOrEmpty(status))
            {
                int state = Convert.ToInt32(status);
                whereExpression = whereExpression.And(u => u.Status.Equals(state));
            }

            var list = _sysUserInfoService.GetList(pagerInfo.PageIndex, pagerInfo.PageSize, out var count, whereExpression, false, u => u.CreatedTime);

            return Json(BuildSuccessTableResult(count, list));
        }

        public IActionResult Form(string objectId)
        {
            //如果objectId不为空的话 需要则是编辑，获取信息否则新建一个
            var sysUserInfo = string.IsNullOrEmpty(objectId)?new SysUserInfo() { Status = (int)Status.On } : _sysUserInfoService.GetList(u => u.ObjectID.Equals(objectId)).FirstOrDefault(); 

            return View(sysUserInfo);
        }

        [HttpPost]
        public IActionResult Form(SysUserInfo sysUserInfo)
        {
            ResponseResult responseResult = new ResponseResult(success:false,message:"保存失败！");
            if (string.IsNullOrEmpty(sysUserInfo.ObjectID))
            {
                sysUserInfo.CreatedBy = CurrentUserManage.UserInfo.URealName;
                sysUserInfo.CreatedTime = DateTime.Now;
                sysUserInfo.ULoginPWD = GlobalSwitch.InitialPassword.ToMD5String();
                sysUserInfo.Status = sysUserInfo.Status == 0 ? 0 : 1;
                _sysUserInfoService.Create(sysUserInfo); 
            }
            else
            {
                var sysUser = _sysUserInfoService.GetList(u => u.ObjectID.Equals(sysUserInfo.ObjectID))
                    .FirstOrDefault();
                if (sysUser != null)
                { 
                    sysUser.URealName = sysUserInfo.URealName;
                    sysUser.UTelphone = sysUserInfo.UTelphone;
                    sysUser.UMobile = sysUserInfo.UMobile;
                    sysUser.UEmail = sysUserInfo.UEmail;
                    sysUser.UQQ = sysUserInfo.UQQ;
                    sysUser.UGender = sysUserInfo.UGender;
                    sysUser.UDepID = sysUserInfo.UDepID;
                    sysUser.Remark = sysUserInfo.Remark;
                    sysUser.Status = sysUserInfo.Status==0?0:1;
                    sysUser.ModifiedTime=DateTime.Now;
                    sysUser.ModifiedBy = CurrentUserManage.UserInfo.URealName;
                    _sysUserInfoService.Edit(sysUser);
                }
            }

            if (_unitOfWork.SaveChanges()==1)
            {
                responseResult.Success = true;
                responseResult.Message = "保存成功！";
            }

            return Json(responseResult);

        }

        [HttpPost]
        public IActionResult Delete(string ids)
        {
            var idsList = ids.ToList<string>();
            _sysUserInfoService.Delete(u=>idsList.Contains(u.ObjectID));
            _unitOfWork.SaveChanges();
            return Json(new ResponseResult(true, "删除成功！"));

        }

        public IActionResult SetRole(string userId)
        {
            ViewData["userId"] = userId;
            //1.获取该用户已经拥有的权限
            ViewData["roleList"] = _sysUserInfoSysRoleService.GetList(r => r.UserInfoID.Equals(userId))
                .Select(r => r.RoleID).ToList();
            //2.搜索所有的角色  禁用的前端控制不可选
            var roleList = _sysRoleService.GetList(r => true).OrderBy(r => r.Sort).ToList();
            return View(roleList);
        }
        [HttpPost]
        public IActionResult SetRole(string userId, string roles)
        {
            List<string> roleList = roles.ToList<string>();
            ResponseResult responseResult = new ResponseResult(false);

            try
            {
                //1.先删除该用户的所有角色
                _sysUserInfoSysRoleService.Delete(r=>r.UserInfoID.Equals(userId));
                //2.循环 roleList 
                foreach (string role in roleList)
                {
                     
                    R_sysUserInfo_sysRole sysUserInfoSysRole = new R_sysUserInfo_sysRole()
                    {
                        UserInfoID = userId,
                        RoleID = role
                    };

                    _sysUserInfoSysRoleService.Create(sysUserInfoSysRole);
                }

                responseResult.Message = "保存成功!";
                responseResult.Success = true;
                _unitOfWork.SaveChanges();
                //todo:3.清缓存
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
                throw;
            }
            return Json(responseResult);

        }
    }
}