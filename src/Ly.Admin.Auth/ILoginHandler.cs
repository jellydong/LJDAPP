using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.Auth
{
    /// <summary>
    /// 登录处理
    /// </summary>
    public interface ILoginHandler
    {
        /// <summary>
        /// 登录处理
        /// </summary>
        /// <param name="claims">信息</param>
        /// <param name="extendData">扩展数据</param>
        /// <returns></returns>
        JwtTokenModel Hand(IEnumerable<Claim> claims, string extendData,string realName);
    }
}
