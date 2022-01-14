using Ly.Admin.Web.Clients;
using Microsoft.AspNetCore.Mvc;

namespace Ly.Admin.Web.Controllers
{
    public class MenuController : BaseController
    {

        public ILogger<MenuController> _logger;
        private readonly IMenuServiceClient _menuServiceClient;

        public MenuController(ILogger<MenuController> logger, IMenuServiceClient menuServiceClient)
        {
            this._logger = logger;
            this._menuServiceClient = menuServiceClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id, int? parentId)
        {
            var menu = await _menuServiceClient.GetById(id, parentId);

            return View(menu.Data);
        }

        [HttpGet]
        public async Task<IActionResult> SelectParent()
        {
            var menuList = await _menuServiceClient.GetParentTree();
            return await Task.Run(() =>
            {
                return Json(new { code = 0, msg = "成功", data = menuList.Data });
            });
        }
    }
}
