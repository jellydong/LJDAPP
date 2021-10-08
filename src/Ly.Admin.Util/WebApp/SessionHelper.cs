using Ly.Admin.Util.Cache;

namespace Ly.Admin.Util.WebApp
{
    public class SessionHelper
    {

        private static string CacheModuleName { get; } = "Session";
        private static string _sessionId { get => HttpContextCore.Current.Request.Cookies[SessionCookieName]; }
        private static string BuildCacheKey(string sessionKey)
        {
            return $"LYAdmin_{CacheModuleName}_{_sessionId}_{sessionKey}";
        }

        /// <summary>
        /// 存放Session标志的Cookie名
        /// </summary>
        public static string SessionCookieName { get; } = "LYAdmin_Session_Id";

        /// <summary>
        /// 当前Session
        /// </summary>
        public static _Session Session { get; } = new _Session();

        /// <summary>
        /// 自定义_Session类
        /// </summary>
        public class _Session
        {
            public object this[string index]
            {
                get
                {
                    string cacheKey = BuildCacheKey(index);
                    return CacheHelper.Cache.GetCache(cacheKey);
                }
                set
                {
                    string cacheKey = BuildCacheKey(index);
                    if (value==null||string.IsNullOrWhiteSpace(value.ToString()))
                        CacheHelper.Cache.RemoveCache(cacheKey);
                    else
                        CacheHelper.Cache.SetCache(cacheKey, value);
                }
            }
        }
    }
}