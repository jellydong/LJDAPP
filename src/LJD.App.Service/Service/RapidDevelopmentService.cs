using System.Collections.Generic;
using LJD.App.Repository.IRepository;
using LJD.App.Service.IService;
using LJD.App.Util;

namespace LJD.App.Service.Service
{
    /// <summary>
    /// 生成代码用 不需要继承Base
    /// </summary>
    public partial class RapidDevelopmentService:IRapidDevelopmentService
    {
        private readonly IRapidDevelopmentRepository _rapidDevelopmentRepository;

        public RapidDevelopmentService(IRapidDevelopmentRepository rapidDevelopmentRepository)
        {
            _rapidDevelopmentRepository = rapidDevelopmentRepository;
        }
        public List<DbTableInfo> GetDbAllTables(string tableName, PagerInfo pagerInfo,out int count)
        {
            return _rapidDevelopmentRepository.GetDbAllTables(tableName, pagerInfo, out  count);
        }
    }
}