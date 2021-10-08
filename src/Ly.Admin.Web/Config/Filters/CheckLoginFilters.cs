using Ly.Admin.Util;
using Ly.Admin.Util.Configuration;
using Ly.Admin.Util.Enum;
using Ly.Admin.Util.Model;
using Ly.Admin.Web.Config.Attribute;
using Ly.Admin.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ly.Admin.Web.Config.Filters
{
    /// <summary>
    /// 登陆验证过滤器
    /// </summary>
    public class CheckLoginFilters : ActionFilterAttribute
    {
        /// <summary>
        /// 统一登陆验证Session【APPKeys.CurrentUser】
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //如果是本地测试模式，不需要校验
            if (GlobalSettings.LyAdminOptions.RunModel == RunModelEnum.LocalTest)
            {
                return;
            }
            //判断是否需要跳过校验
            bool isSkipCheckLogin = context.ActionDescriptor.EndpointMetadata.Any(a => a.GetType() == typeof(SkipCheckLoginAttribute));

            //1.判断 如果没有登陆并且 需要验证登陆
            if (!CurrentUserManage.IsLogin() && !isSkipCheckLogin)
            {
                //2.1 Ajax请求 返回
                if (context.HttpContext.Request.IsAjaxRequest())
                {
                    ResponseResult responseResult = new ResponseResult(false, "抱歉，没有登录或登录已超时!");
                    context.Result = new JsonResult(responseResult);
                    return;
                }
                //2.2  跳转到登陆页面 
                context.Result = new RedirectResult("~/Account/Login");
            }
        }
    }
}
