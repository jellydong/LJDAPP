﻿using AutoMapper;
using Ly.Admin.Resources;
using Ly.Admin.Util.Enum;
using Ly.Admin.Util.Model;
using Ly.Admin.Web.Clients;
using Ly.Admin.Web.Config.Attribute;
using Ly.Admin.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ly.Admin.Web.Controllers
{

    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAuthServiceClient _authServiceClient;
        private readonly IAccountServiceClient _accountServiceClient;

        public AccountController(ILogger<AccountController> logger, IAuthServiceClient authServiceClient, IAccountServiceClient accountServiceClient)
        {
            _logger = logger;
            _authServiceClient = authServiceClient;
            _accountServiceClient = accountServiceClient;
        }

        [SkipCheckLogin]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [SkipCheckLogin]
        public async Task<IActionResult> Login(LoginInfoModel loginInfo)
        {

            _logger.LogInformation($"用户登录{JsonConvert.SerializeObject(loginInfo)}");
            ResponseResult responseResult = new ResponseResult(false, "未执行！");
            try
            {
                loginInfo.VerifyCode = new VerifyCodeModel()
                {
                    Id = string.Empty,
                    Code = string.Empty
                };

                var result = await _authServiceClient.Login(loginInfo);
                if (result.Code.Equals(ResultEnum.SUCCESS))
                {
                    ////登陆
                    CurrentUserManage.Login(result.Result);
                }
                else
                {
                    responseResult.Message = result.Message;
                }

                responseResult.Message = "登陆成功！";
                responseResult.Code = ResultEnum.SUCCESS;
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult);
        }

        [HttpGet]
        public async Task<IActionResult> PermissionMenu()
        {
            var permissionMenu = await _accountServiceClient.PermissionMenu();
            if (permissionMenu.Code.Equals(ResultEnum.SUCCESS))
            {
                return Json(permissionMenu.Result);
            }
            return Json(permissionMenu.Message);
        }
    }

}
