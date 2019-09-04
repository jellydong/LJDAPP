using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LJD.App.Model.DbModels;
using LJD.App.Repository.IUnitOfWork;
using LJD.App.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LJD.App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IR_RolePermissionService _rolePermissionService;
        private readonly ISysRoleService _sysRoleService;
        private readonly IR_sysUserInfo_sysRoleService _sysUserInfoSysRoleService;

        public TestController(IR_RolePermissionService rolePermissionService,ISysRoleService sysRoleService,IR_sysUserInfo_sysRoleService sysUserInfoSysRoleService)
        {
            _rolePermissionService = rolePermissionService;
            _sysRoleService = sysRoleService;
            _sysUserInfoSysRoleService = sysUserInfoSysRoleService;
        }

        public string Get()
        {
            string userId = "D451D121-0AA5-4ECF-BD2A-2CDA443F795D";
            //获取用户拥有的角色
            var roles = _sysUserInfoSysRoleService.GetList(r => r.UserInfoID.Equals(userId)).Select(r=>r.RoleID).ToList();
            //通过角色获取权限项
            var data = _rolePermissionService.GetList(r=> roles.Contains(r.RoleID)).Select(r=>new
            { 
                r.MenuID,
                r.FunctionID
            }).ToList();

            var enumerable = data.Distinct().ToList();

            return JsonConvert.SerializeObject(data);
        }
    }
}