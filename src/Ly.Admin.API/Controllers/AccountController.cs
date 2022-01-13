using Ly.Admin.Resources;
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
        [HttpGet("PermissionMenu")]
        public async Task<ResponseResult> PermissionMenu()
        {


            List<PermissionMenuResource> permissionMenus = new List<PermissionMenuResource>();

            permissionMenus.Add(new PermissionMenuResource()
            {
                Id = 1,
                Title = "工作空间",
                Icon = "layui-icon layui-icon-console",
                Type = 0,
                Children = new List<PermissionMenuResource>()
                {
                    new PermissionMenuResource()
                    {
                        Id = 101,
                        Title = "控制后台",
                        Icon = "layui-icon layui-icon-console",
                        Type = 1,
                        OpenType = "_iframe",
                        Href = "/lib/pear-admin-layui/view/console/console1.html",
                    },
                    new PermissionMenuResource()
                    {
                        Id = 104,
                        Title = "数据分析",
                        Icon = "layui-icon layui-icon-console",
                        Type = 1,
                        OpenType = "_iframe",
                        Href = "/lib/pear-admin-layui/view/console/console2.html",
                    },
                    new PermissionMenuResource()
                    {
                        Id = 102,
                        Title = "百度一下",
                        Icon = "layui-icon layui-icon-console",
                        Type = 1,
                        OpenType = "_iframe",
                        Href = "http://www.baidu.com",
                    },
                    new PermissionMenuResource()
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

            permissionMenus.Add(new PermissionMenuResource()
            {
                Id = 2,
                Title = "常用组件",
                Icon = "layui-icon layui-icon-component",
                Type = 0,
                Children = new List<PermissionMenuResource>()
                {
                    new PermissionMenuResource()
                    {
                        Id = 201,
                        Title = "基础组件",
                        Icon = "layui-icon layui-icon-console",
                        Type = 0,
                        Children = new List<PermissionMenuResource>()
                        {
                            new PermissionMenuResource()
                            {
                                Id = 2011,
                                Title = "功能按钮",
                                Icon = "layui-icon layui-icon-face-smile",
                                Type = 1,
                                OpenType = "_iframe",
                                Href = "/lib/pear-admin-layui/view/document/button.html",
                            },
                            new PermissionMenuResource()
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
                    new PermissionMenuResource()
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

            permissionMenus.Add(new PermissionMenuResource()
            {
                Id = 888,
                Title = "系统管理",
                Icon = "layui-icon layui-icon-set-fill",
                Type = 0,
                Children = new List<PermissionMenuResource>()
                {

                    new PermissionMenuResource()
                    {
                        Id = 88801,
                        Title = "菜单管理",
                        Icon = "layui-icon layui-icon-face-cry",
                        Type = 1,
                        OpenType = "_iframe",
                        Href = "Menu/Index",
                    },
                    new PermissionMenuResource()
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
            return await Task.FromResult(new ResponseResult<List<PermissionMenuResource>>(true, permissionMenus));
        }
    }
}
