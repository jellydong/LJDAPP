using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ly.Admin.Util;

namespace Ly.Admin.Auth
{
    /// <summary>
    /// 登录用户信息
    /// todo:这里用到的拓展方法,抽时间优化下
    /// </summary>
    public class LoginInfo : ILoginInfo
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginInfo(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public long AccountId
        {
            get
            {
                var accountId = _contextAccessor?.HttpContext?.User?.FindFirst(ClaimsName.AccountId);

                if (accountId != null && accountId.Value.NotNull())
                {
                    return accountId.Value.ToLong();
                }
                return 0;
            }
        }
        public string AccountName
        {
            get
            {
                var accountName = _contextAccessor?.HttpContext?.User?.FindFirst(ClaimsName.AccountName);

                if (accountName == null || accountName.Value.IsNull())
                {
                    return "";
                }
                return accountName.Value;
            }
        }
        public int AccountType
        {
            get
            {
                var ty = _contextAccessor?.HttpContext?.User?.FindFirst(ClaimsName.AccountType);
                if (ty != null && ty.Value.NotNull())
                {
                    return ty.Value.ToInt();
                }

                return -1;
            }
        }

        public int Platform
        {
            get
            {
                var pf = _contextAccessor?.HttpContext?.User?.FindFirst(ClaimsName.Platform);

                if (pf != null && pf.Value.NotNull())
                {
                    return pf.Value.ToInt();
                }

                return 0;
            }
        }

        public string IP
        {
            get
            {
                if (_contextAccessor?.HttpContext?.Connection == null)
                    return "";

                return _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }
        }

        public string IPv4
        {
            get
            {
                if (_contextAccessor?.HttpContext?.Connection == null)
                    return "";

                return _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }

        public string IPv6
        {
            get
            {
                if (_contextAccessor?.HttpContext?.Connection == null)
                    return "";

                return _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv6().ToString();
            }
        }

        public long LoginTime
        {
            get
            {
                var ty = _contextAccessor?.HttpContext?.User?.FindFirst(ClaimsName.LoginTime);

                if (ty != null && ty.Value.NotNull())
                {
                    return ty.Value.ToLong();
                }

                return 0L;
            }
        }

        public string UserAgent
        {
            get
            {
                if (_contextAccessor?.HttpContext?.Request == null)
                    return "";

                return _contextAccessor.HttpContext.Request.Headers["User-Agent"];
            }
        }
    }
}
