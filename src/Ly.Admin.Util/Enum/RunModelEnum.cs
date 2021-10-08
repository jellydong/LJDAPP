using System.ComponentModel;

namespace Ly.Admin.Util.Enum
{
    public enum RunModelEnum
    {
        /// <summary>
        /// 本地测试模式，默认Admin账户，不需要登录
        /// </summary>
        [Description("本地测试模式")]
        LocalTest = 0,

        /// <summary>
        /// 发布模式
        /// </summary>
        [Description("发布模式")]
        Publish = 1
    }
}