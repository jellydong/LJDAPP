
using Ly.Admin.API.Config.Attribute;
using Ly.Admin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Ly.Admin.API.Config.Filters;
public class PermissionValidateFilter : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var hasAuthorizeCode = (PermissionValidateAttribute)context.ActionDescriptor.EndpointMetadata.FirstOrDefault(a => a.GetType() == typeof(PermissionValidateAttribute));
        //判断是否定义了授权码
        if (hasAuthorizeCode != null && !string.IsNullOrEmpty(hasAuthorizeCode.AuthorizeCode))
        {
            //未登录
            var loginInfo = context.HttpContext.RequestServices.GetService<ILoginInfo>();
            if (loginInfo == null || loginInfo.AccountId == 0)
            {
                context.Result = new ChallengeResult();//未授权 401
                return;
            }
            //todo:进行权限验证

        }
    }
}
