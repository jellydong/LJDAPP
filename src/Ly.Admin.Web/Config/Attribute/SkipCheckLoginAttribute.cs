namespace Ly.Admin.Web.Config.Attribute
{
    /// <summary>
    /// 跳过登陆验证 只能打在方法或类上
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class SkipCheckLoginAttribute : System.Attribute
    {

    }
}
