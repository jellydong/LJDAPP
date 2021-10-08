

using System.ComponentModel;

namespace Ly.Admin.Util.Enum
{
    public enum StatusEnum
    {
        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Yes = 1,
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        No = 0
    }

    public enum IsEnum
    {
        /// <summary>
        /// 是
        /// </summary>
        [Description("是")]
        Yes = 1,
        /// <summary>
        /// 否
        /// </summary>
        [Description("否")]
        No = 0
    }

    public enum NeedEnum
    {
        /// <summary>
        /// 不需要
        /// </summary>
        [Description("不需要")]
        NotNeed = 0,
        /// <summary>
        /// 需要
        /// </summary>
        [Description("需要")]
        Need = 1
    }

    public enum OperateStatusEnum
    {
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail = 0,
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 1
    }

    public enum Gender
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown = 0,
        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Male = 1,
        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        Female = 1
    }

}