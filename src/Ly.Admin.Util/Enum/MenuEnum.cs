using System.ComponentModel;

namespace Ly.Admin.Util.Enum
{

    public enum MenuTypeEnum
    {
        /// <summary>
        /// 目录
        /// </summary>
        [Description("目录")]
        Directory = 0,
        /// <summary>
        /// 页面
        /// </summary>
        [Description("页面")]
        Menu = 1,
        /// <summary>
        /// 功能(按钮)
        /// </summary>
        [Description("功能(按钮)")]
        Button = 2
    }
    public enum MenuOpenTypeEnum
    {
        /// <summary>
        /// Iframe
        /// </summary>
        [Description("Iframe")]
        Iframe = 0,
        /// <summary>
        /// Blank
        /// </summary>
        [Description("Blank")]
        Blank = 1,
    }
}