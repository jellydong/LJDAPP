using System.Collections.Generic;
using LJD.App.Util;

namespace LJD.App.Repository.Repository
{
    public class RapidDevelopmentRepository:IRepository.IRapidDevelopmentRepository
    {
        private readonly SqlHelper _sqlHelper=new SqlHelper();
         
        public List<DbTableInfo> GetDbAllTables(string tableName, PagerInfo pagerInfo, out int count)
        {
            string strsql = string.Format(@"select
[TableName] = a.name,
[Description] = g.value
from
  sys.tables a left join sys.extended_properties g
  on (a.object_id = g.major_id AND g.minor_id = 0 AND g.name= 'MS_Description')
  WHERE a.name LIKE '%{0}%'
UNION
select
[TableName] = a.name,
[Description] = g.value
from
  sys.views a left join sys.extended_properties g
  on (a.object_id = g.major_id AND g.minor_id = 0 AND g.name= 'MS_Description')
  WHERE a.name LIKE '%{0}%'", tableName);
            var data = _sqlHelper.GetPagerList<DbTableInfo>(pagerInfo.PageSize, pagerInfo.PageIndex, "TableName", strsql,
                out count);

            return data;
        }
    }
}