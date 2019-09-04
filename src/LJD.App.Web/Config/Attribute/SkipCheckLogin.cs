using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LJD.App.Web
{
    /// <summary>
    /// 跳过登陆验证 只能打在方法或类上
    /// </summary>
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class,AllowMultiple = false)]
    public class SkipCheckLogin : System.Attribute
    {

    }
}
