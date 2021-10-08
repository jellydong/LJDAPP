using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.Auth
{
    /// <summary>
    /// 登录信息
    /// </summary>
    public interface ILoginInfo
    {
        /// <summary>
        /// 账户id
        /// </summary>
        long AccountId { get; }

        /// <summary>
        /// 账户名称
        /// </summary>
        string AccountName { get; }

        /// <summary>
        /// 账户类型
        /// </summary>
        int AccountType { get; }

        /// <summary>
        /// 平台
        /// </summary>
        int Platform { get; }

        /// <summary>
        /// 获取当前用户IP(包含IPv4和IPv6)
        /// </summary>
        string IP { get; }

        /// <summary>
        /// 获取当前用户IPv4
        /// </summary>
        string IPv4 { get; }

        /// <summary>
        /// 获取当前用户IPv6
        /// </summary>
        string IPv6 { get; }

        /// <summary>
        /// 登录时间戳
        /// </summary>
        long LoginTime { get; }

        /// <summary>
        /// 获取当前用户请求的User-Agent
        /// </summary>
        string UserAgent { get; }
    }
}
