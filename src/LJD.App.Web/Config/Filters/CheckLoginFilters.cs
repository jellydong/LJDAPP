using System.Collections.Generic;
using System.Linq;
using LJD.App.Service;
using LJD.App.Util; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LJD.App.Web
{
    /// <summary>
    /// 登陆验证过滤器
    /// </summary>
    public class CheckLoginFilters:ActionFilterAttribute
    {
        /// <summary>
        /// 统一登陆验证Session【APPKeys.CurrentUser】
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //如果是本地测试模式，不需要校验
            if (GlobalSwitch.RunModel == RunModel.LocalTest)
            {
                return;
            }
            //判断是否需要跳过校验
            bool isSkipCheckLogin= context.ActionDescriptor.EndpointMetadata.Any(a=>a.GetType() == typeof(SkipCheckLogin));

            //1.判断 如果没有登陆并且 需要验证登陆的，则跳转到登陆页面 
            if (!CurrentUserManage.IsLogin()&&!isSkipCheckLogin)
            {
                 
                //2.跳转到登陆页面
                context.Result = new ViewResult() {ViewName = "/Views/Shared/Tip.cshtml"};
            } 
        }
    }
}