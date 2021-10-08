using Ly.Admin.Auth;
using Ly.Admin.Resources;
using Ly.Admin.Util.Cache;
using Ly.Admin.Util.Configuration;
using Ly.Admin.Util.Enum;
using Ly.Admin.Util.WebApp;
using System.Security.Claims;

namespace Ly.Admin.Web.Helper
{

    /// <summary>
    /// 用户相关信息
    /// </summary>
    public static class CurrentUserManage
    {
        /// <summary>
        /// 当前登陆用户
        /// </summary>
        public static JwtTokenModel? UserInfo
        {
            get
            {

                //获取客户端Cookies
                var userLoginId = HttpContextCore.Current.Request.Cookies[GlobalSettings.LyAdminOptions.DefaultAppKeys.CurrentUser];
                //如果客户端Cookies不为null
                if (!string.IsNullOrEmpty(userLoginId) && CacheHelper.Cache.GetCache<JwtTokenModel>(userLoginId) != null)
                {
                    return CacheHelper.Cache.GetCache<JwtTokenModel>(userLoginId);
                }
                if (GlobalSettings.LyAdminOptions.RunModel == RunModelEnum.LocalTest)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsName.AccountId, "1"),
                        new Claim(ClaimsName.AccountName, "DEBUG管理员"),
                        new Claim(ClaimsName.LoginTime, DateTime.Now.ToString())
                    };
                    var _loginHandler = AutofacHelper.GetService<ILoginHandler>();
                    var jwtmodel = _loginHandler.Hand(claims, "2d9ff75343b34858884c528b5dd5ff3b", "DEBUG管理员");

                    Login(jwtmodel);

                    return jwtmodel;
                }
                return null;
            }
        }

        /// <summary>
        /// 是否已登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            return UserInfo != null;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userInfo"></param>
        public static void Login(JwtTokenModel userInfo)
        {
            string userLoginId = Guid.NewGuid().ToString();
            //往客户端写入Cookie
            HttpContextCore.Current.Response.Cookies.Append(GlobalSettings.LyAdminOptions.DefaultAppKeys.CurrentUser, userLoginId, new CookieOptions() { HttpOnly = true });
            HttpContextCore.Current.Response.Cookies.Append("text", "12345", new CookieOptions { Expires = DateTime.MaxValue, HttpOnly = true });
            //把登陆用户保存到缓存中
            CacheHelper.Cache.SetCache(userLoginId, userInfo, TimeSpan.FromMinutes(30), ExpireTypeEnum.Relative);
        }

        /// <summary>
        /// 注销
        /// </summary>
        public static void Logout()
        {
            //获取客户端Cookies
            var userLoginId = HttpContextCore.Current.Request.Cookies[GlobalSettings.LyAdminOptions.DefaultAppKeys.CurrentUser];
            if (userLoginId != null)
            {
                //清空缓存
                CacheHelper.Cache.RemoveCache(userLoginId);
                //清空客户端Cookies
                HttpContextCore.Current.Response.Cookies.Delete(GlobalSettings.LyAdminOptions.DefaultAppKeys.CurrentUser);
            }
        }
    }


}
