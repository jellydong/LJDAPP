using System.Linq;
using LJD.App.Model.ViewModels;
using LJD.App.Service;
using LJD.App.Service.IService;
using LJD.App.Util; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LJD.App.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SkipCheckLogin]
    [SkipCheckPermission]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowVercode()
        {
            var imgBytes = _loginService.GetVcode();
            return File(imgBytes, @"image/jpeg");
        }

        public IActionResult Login(LoginInfo loginInfo)
        { 
            ResponseResult responseResult = _loginService.Login(loginInfo);  
             
            return Json(responseResult);
        }
        public IActionResult Logout()
        {
            CurrentUserManage.Logout();
            return View("Index");
        }
    }
}