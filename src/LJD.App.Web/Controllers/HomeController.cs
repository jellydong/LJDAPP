using System.Diagnostics;
using LJD.App.Repository.IUnitOfWork;
using LJD.App.Service.IService;
using Microsoft.AspNetCore.Mvc;
using LJD.App.Web.Models;

namespace LJD.App.Web.Controllers
{
    [SkipCheckPermission]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
