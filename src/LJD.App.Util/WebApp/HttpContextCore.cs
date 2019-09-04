using Microsoft.AspNetCore.Http;

namespace LJD.App.Util
{
    public class HttpContextCore
    {
        public static HttpContext Current { get => AutofacHelper.GetService<IHttpContextAccessor>().HttpContext; }
    }
}