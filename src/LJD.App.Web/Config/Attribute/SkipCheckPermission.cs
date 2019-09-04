using System;

namespace LJD.App.Web
{
    /// <summary>
    /// 跳过权限验证 只能打在方法或类上
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class SkipCheckPermission : System.Attribute
    {
        
    }
}