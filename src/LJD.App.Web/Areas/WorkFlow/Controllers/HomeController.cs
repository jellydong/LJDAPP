using LJD.App.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LJD.App.Web.Areas.WorkFlow.Controllers
{
    [Area("WorkFlow")]
    public class HomeController : BaseController
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }

    }
}