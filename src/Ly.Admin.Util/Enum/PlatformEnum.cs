using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ly.Admin.Util.Enum
{
    /// <summary>
    /// 平台类型
    /// </summary>
    public enum PlatformEnum
    {
        [Description("未知")]
        UnKnown = -1,
        /// <summary>
        /// Web
        /// </summary>
        [Description("Web")]
        Web,
        /// <summary>
        /// Mobile
        /// </summary>
        [Description("手机")]
        Mobile,
        /// <summary>
        /// WeChat
        /// </summary>
        [Description("微信")]
        WeChat
    }
}
