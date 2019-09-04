using System.Linq;
using LJD.App.Model.DbModels;
using LJD.App.Repository.IUnitOfWork;
using LJD.App.Service;
using LJD.App.Service.IService;
using LJD.App.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LJD.App.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IPostService _postService;

        public HomeController(IUnitOfWork unitOfWork,   IPostService postService)
        {
            _unitOfWork = unitOfWork; 
            _postService = postService;
        }
        public IActionResult Index()
        {

            var permissionMenu = CurrentUserManage.UserPermissionMenu;
            ViewData["aaa"] = "你好啊";
            ViewData["Menus"] = JsonConvert.SerializeObject(permissionMenu,Formatting.Indented,new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }); 

            return View();
        }

        public IActionResult Desktop()
        {
            return View();
        }
        public IActionResult WelCome()
        {
            return View();
        } 
    }
}