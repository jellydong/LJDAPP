using Ly.Admin.Auth;
using Ly.Admin.Resources;
using Ly.Admin.Util.Enum;
using Ly.Admin.Util.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ly.Admin.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ILoginInfo _loginInfo;

        public AccountController(ILogger<AccountController> logger, ILoginInfo loginInfo)
        {
            _logger = logger;
            _loginInfo = loginInfo;
        }
        [HttpGet("PermissionMenu")]
        public async Task<ResponseResult> PermissionMenu()
        {
            List<PermissionMenuResource> permissionMenuResources = new List<PermissionMenuResource>();
            var dashboardRoute = new PermissionMenuResource
            {
                Path = "/dashboard",
                Name = "Dashboard",
                Component = "LAYOUT",
                Redirect = "/dashboard/analysis",
                Meta = new VueRouterMetaResource
                {
                    Title = "routes.dashboard.dashboard",
                    Icon = "bx:bx-home"
                },
                Children = new List<PermissionMenuResource>
                {
                    new PermissionMenuResource
                    {
                        Path = "analysis",
                        Name = "Analysis",
                        Component = "/dashboard/analysis/index",
                        Meta = new VueRouterMetaResource
                        {
                            Title = "routes.dashboard.analysis",
                            CurrentActiveMenu = "/dashboard",
                            Icon = "bx:bx-home"
                        }
                    }, 
                    new PermissionMenuResource
                    {
                        Path = "workbench",
                        Name = "Workbench",
                        Component = "/dashboard/workbench/index",
                        Meta = new VueRouterMetaResource
                        {
                            Title = "routes.dashboard.workbench",
                            CurrentActiveMenu = "/dashboard",
                            Icon = "bx:bx-home"
                        }
                    }
                }
            };


            permissionMenuResources.Add(dashboardRoute);

            return await Task.FromResult(new ResponseResult<List<PermissionMenuResource>>(ResultEnum.SUCCESS, permissionMenuResources));
        }
        [HttpGet("PermCode")]
        public async Task<ResponseResult> GetPermCode()
        {
            return await Task.FromResult(new ResponseResult<List<string>>(true,new List<string> { "1000", "3000", "5000" }));
        }

        [HttpGet("PermissionMenuPearAdmin")]
        public async Task<ResponseResult> PermissionMenuPearAdmin()
        {
            List<PermissionMenuResourcePearAdmin> permissionMenus = new List<PermissionMenuResourcePearAdmin>();

            permissionMenus.Add(new PermissionMenuResourcePearAdmin()
            {
                Id = 1,
                Title = "工作空间",
                Icon = "layui-icon layui-icon-console",
                Type = 0,
                Children = new List<PermissionMenuResourcePearAdmin>()
                {
                    new PermissionMenuResourcePearAdmin()
                    {
                        Id = 101,
                        Title = "控制后台",
                        Icon = "layui-icon layui-icon-console",
                        Type = 1,
                        OpenType = "_iframe",
                        Href = "/lib/pear-admin-layui/view/console/console1.html",
                    },
                    new PermissionMenuResourcePearAdmin()
                    {
                        Id = 104,
                        Title = "数据分析",
                        Icon = "layui-icon layui-icon-console",
                        Type = 1,
                        OpenType = "_iframe",
                        Href = "/lib/pear-admin-layui/view/console/console2.html",
                    },
                    new PermissionMenuResourcePearAdmin()
                    {
                        Id = 102,
                        Title = "百度一下",
                        Icon = "layui-icon layui-icon-console",
                        Type = 1,
                        OpenType = "_iframe",
                        Href = "http://www.baidu.com",
                    },
                    new PermissionMenuResourcePearAdmin()
                    {
                        Id = 103,
                        Title = "Hello World",
                        Icon = "layui-icon layui-icon-console",
                        Type = 1,
                        OpenType = "_iframe",
                        Href = "/Home/HelloWorld",
                    }
                }
            });

            permissionMenus.Add(new PermissionMenuResourcePearAdmin()
            {
                Id = 2,
                Title = "常用组件",
                Icon = "layui-icon layui-icon-component",
                Type = 0,
                Children = new List<PermissionMenuResourcePearAdmin>()
                {
                    new PermissionMenuResourcePearAdmin()
                    {
                        Id = 201,
                        Title = "基础组件",
                        Icon = "layui-icon layui-icon-console",
                        Type = 0,
                        Children = new List<PermissionMenuResourcePearAdmin>()
                        {
                            new PermissionMenuResourcePearAdmin()
                            {
                                Id = 2011,
                                Title = "功能按钮",
                                Icon = "layui-icon layui-icon-face-smile",
                                Type = 1,
                                OpenType = "_iframe",
                                Href = "/lib/pear-admin-layui/view/document/button.html",
                            },
                            new PermissionMenuResourcePearAdmin()
                            {
                                Id = 2012,
                                Title = "表单集合",
                                Icon = "layui-icon layui-icon-face-cry",
                                Type = 1,
                                OpenType = "_iframe",
                                Href = "/lib/pear-admin-layui/view/document/form.html",
                            }
                        }
                    },
                    new PermissionMenuResourcePearAdmin()
                    {
                        Id = 202,
                        Title = "列表测试",
                        Icon = "layui-icon layui-icon-console",
                        Type = 1,
                        OpenType = "_iframe",
                        Href = "/lib/pear-admin-layui/view/system/power.html",
                    }
                }
            });

            permissionMenus.Add(new PermissionMenuResourcePearAdmin()
            {
                Id = 888,
                Title = "系统管理",
                Icon = "layui-icon layui-icon-set-fill",
                Type = 0,
                Children = new List<PermissionMenuResourcePearAdmin>()
                {

                    new PermissionMenuResourcePearAdmin()
                    {
                        Id = 88801,
                        Title = "菜单管理",
                        Icon = "layui-icon layui-icon-face-cry",
                        Type = 1,
                        OpenType = "_iframe",
                        Href = "Menu/Index",
                    },
                    new PermissionMenuResourcePearAdmin()
                    {
                        Id = 88802,
                        Title = "用户管理",
                        Icon = "layui-icon layui-icon-face-smile",
                        Type = 1,
                        OpenType = "_iframe",
                        Href = "/lib/pear-admin-layui/view/system/user.html",
                    }
                }
            });
            return await Task.FromResult(new ResponseResult<List<PermissionMenuResourcePearAdmin>>(ResultEnum.SUCCESS, permissionMenus));
        }
    }
}
