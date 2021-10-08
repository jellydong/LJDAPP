using Microsoft.AspNetCore.Http;
namespace Ly.Admin.Util.WebApp
{
    public class HttpContextCore
    { 
        public static HttpContext Current { get => AutofacHelper.GetService<IHttpContextAccessor>().HttpContext; }
    }
}