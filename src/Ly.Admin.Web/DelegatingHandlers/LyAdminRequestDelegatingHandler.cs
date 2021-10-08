using Ly.Admin.Util.WebApp;
using Ly.Admin.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Serilog.Extensions.Logging;
using System.Net;
using System.Net.Http.Headers;

namespace Ly.Admin.Web.DelegatingHandlers
{
    public class LyAdminRequestDelegatingHandler : DelegatingHandler
    {

        public readonly ILogger<LyAdminRequestDelegatingHandler> _logger = ((SerilogLoggerFactory)AutofacHelper.GetService<ILoggerFactory>()).CreateLogger<LyAdminRequestDelegatingHandler>();

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"发送请求 {request.RequestUri } ");

            //处理请求
            request.Headers.Add("x-guid", Guid.NewGuid().ToString());//可以添加

            if (CurrentUserManage.IsLogin())
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", CurrentUserManage.UserInfo.AccessToken);
            }
            var result = await base.SendAsync(request, cancellationToken); //调用内部handler 不调用的话就不真正发送请求
            _logger.LogInformation(result.ToString());
            //HttpContextCore.Current.Response.Clear();
            //HttpContextCore.Current.Response.WriteAsync("<script language=\"javascript\">self.location='Account/Login';</script>");
            //处理响应  
            return result;
        }
    }
}
