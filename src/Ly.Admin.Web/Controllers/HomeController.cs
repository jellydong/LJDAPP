using Ly.Admin.Web.Clients;
using Ly.Admin.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ly.Admin.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherForecastServiceClient _weatherForecastServiceClient;

        public HomeController(ILogger<HomeController> logger, IWeatherForecastServiceClient weatherForecastServiceClient)
        {
            _logger = logger;
            _weatherForecastServiceClient = weatherForecastServiceClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> HelloWorld()
        {
            ViewBag.message = await _weatherForecastServiceClient.HelloWorld();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}