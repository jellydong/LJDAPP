using System;
using System.Collections.Generic;
using System.Text;
using LJD.App.Util;

namespace LJD.App.Service.IService
{
    /// <summary>
    /// 生成代码用 不需要继承Base
    /// </summary>
    public interface IRapidDevelopmentService
    {
        List<DbTableInfo> GetDbAllTables(string tableName, PagerInfo pagerInfo, out int count);
    }
}
