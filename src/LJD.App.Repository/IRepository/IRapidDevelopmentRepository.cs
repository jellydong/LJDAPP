using System.Collections.Generic;
using LJD.App.Util;

namespace LJD.App.Repository.IRepository
{
    /// <summary>
    /// 生成代码用 不需要继承Base
    /// </summary>
    public interface IRapidDevelopmentRepository
    {
        List<DbTableInfo> GetDbAllTables(string tableName, PagerInfo pagerInfo, out int count);
    }
}