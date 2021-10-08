using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ly.Admin.Data.EF.Database;
using Ly.Admin.Model;
using Microsoft.EntityFrameworkCore;
using Ly.Admin.IRepositories;

namespace Ly.Admin.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
        private readonly LyAdminDbContext _lyAdminDbContext;

        public BaseRepository(LyAdminDbContext lyAdminDbContext)
        {
            _lyAdminDbContext = lyAdminDbContext ?? throw new ArgumentNullException(nameof(lyAdminDbContext));
        }

        public void Insert(T model)
        {
            _lyAdminDbContext.Set<T>().Add(model);
        }

        public void Insert(IEnumerable<T> modeList)
        {
            _lyAdminDbContext.Set<T>().AddRange(modeList);
        }

        public void Update(T model)
        {
            _lyAdminDbContext.Entry<T>(model).State = EntityState.Modified;
        }

        public void Update(T model, List<string> properties)
        {

            //1 验证
            if (model == null)
            {
                throw new Exception("实体不能为空！");
            }

            if (properties.Any() == false)
            {
                throw new Exception("要修改的属性至少有一个！");
            }
            _lyAdminDbContext.Entry<T>(model).State = EntityState.Unchanged;
            //2 将model追加到EF容器 
            foreach (var item in properties)
            {
                _lyAdminDbContext.Entry<T>(model).Property(item).IsModified = true;
            }
        }

        public void Delete(T model)
        {
            _lyAdminDbContext.Set<T>().Remove(model);
        }

        public void Delete(Expression<Func<T, bool>> whereLambda)
        {
            var deleteList = GetList().Where(whereLambda).ToList();
            foreach (var entity in deleteList)
            {
                Delete(entity);
            }
        }

        public IQueryable<T> GetList()
        {
            return _lyAdminDbContext.Set<T>();
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return _lyAdminDbContext.Set<T>().Where(whereLambda).AsQueryable();
        }

        public IQueryable<T> GetList<TS>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, bool isAsc,
            Expression<Func<T, TS>> orderByLambda)
        {

            var queryable = _lyAdminDbContext.Set<T>().Where(whereLambda);
            total = queryable.Count();
            if (isAsc)
            {
                queryable = queryable.
                    OrderBy(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize);
            }
            else
            {
                queryable = queryable
                    .OrderByDescending(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize);
            }
            return queryable;
        }

        public IQueryable<T> FromSql(string sql, params object[] parameters)
        {
            return _lyAdminDbContext.Set<T>().FromSqlRaw<T>(sql, parameters);
        }
    }
}