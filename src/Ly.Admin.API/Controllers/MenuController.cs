using AutoMapper;
using Ly.Admin.IServices;
using Ly.Admin.Resources;
using Ly.Admin.Util.Enum;
using Ly.Admin.Util.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ly.Admin.API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IMapper _mapper;
        private readonly IMenuService _menuService;

        public MenuController(ILogger<MenuController> logger, IMapper mapper, IMenuService menuService)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._menuService = menuService;
        }
        [HttpGet("GetById")]
        public Task<ResponseResult<MenuResource>> GetById(int id, int? parentId)
        {
            var menu = _mapper.Map<MenuResource>(_menuService.GetEntity(id)) ?? new MenuResource() { ParentId = parentId ?? 0, MenuType = MenuTypeEnum.Menu, IsDisplay = IsEnum.Yes, Status = StatusEnum.Yes };

            return Task.FromResult(new ResponseResult<MenuResource>(true, menu));
        }
        [HttpGet("GetParentTree")]
        public Task<ResponseResult<List<MenuResource>>> GetParentTree()
        {
            var menuList = _mapper.Map<List<MenuResource>>(_menuService.GetList(m => m.MenuType != MenuTypeEnum.Button && m.Status == StatusEnum.Yes));
            menuList.Add(new MenuResource()
            {
                Id = 0,
                Name = "顶级权限",
                ParentId = -1
            });

            return Task.FromResult(new ResponseResult<List<MenuResource>>(true, menuList));
        }
    }
}
