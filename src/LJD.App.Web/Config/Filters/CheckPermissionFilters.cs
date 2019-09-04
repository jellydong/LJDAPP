using System.Collections.Generic;
using System.Linq;
using LJD.App.Service;
using LJD.App.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace LJD.App.Web
{
    /// <summary>
    /// 权限验证过滤器
    /// </summary>
    public class CheckPermissionFilters : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            //判断是否需要跳过校验
            bool isSkipCheckPermission = context.ActionDescriptor.EndpointMetadata.Any(a => a.GetType() == typeof(SkipCheckPermission));
            //如果不跳过权限校验
            if (!isSkipCheckPermission)
            { 
                //获取当前的URL
                string url = request.Path.Value.ToLower(); 
                 
                //对比权限缓存中是否存在该权限  不存在的话
                if (CurrentUserManage.UserPermissionList.FirstOrDefault(p =>!string.IsNullOrEmpty(p.FURL)&& p.FURL.ToLower().StartsWith(url)) == null)
                {
                    //判断是不是Ajax请求
                    if (request.IsAjaxRequest())
                    {
                        context.Result = new ContentResult
                        {
                            Content = new ResponseResult(false, "您没有权限执行此操作!").ToJson(),
                            ContentType = "application/json;charset=UTF-8"
                        };
                    }
                    else
                    {
                        //2.跳转到 错误页面
                        context.Result = new ViewResult() { ViewName = "/Views/Shared/ErrorPermission.cshtml" };
                    }
                }
            }
        }
    }
}