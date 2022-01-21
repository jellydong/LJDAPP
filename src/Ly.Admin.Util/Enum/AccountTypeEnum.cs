using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.Util.Enum
{
   /// <summary>
    /// 平台类型
    /// </summary>
    public enum AccountTypeEnum
    {
        [Description("未知")]
        UnKnown, 
        /// <summary>
        /// USER
        /// </summary>
        [Description("USER")]
        USER,
        /// <summary>
        /// API
        /// </summary>
        [Description("API")]
        API
    }
}
