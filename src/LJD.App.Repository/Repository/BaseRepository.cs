using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 
using LJD.App.Model.DbModels;
using Microsoft.EntityFrameworkCore;

namespace LJD.App.Repository.Repository
{
    public class BaseRepository<T> where T:class,new()
    {
        private readonly LJDAPPContext _ljdAppContext;

        public BaseRepository(LJDAPPContext ljdAppContext)
        {
            _ljdAppContext = ljdAppContext;
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>成功失败</returns>
        public void Create(T model)
        {
            _ljdAppContext.Set<T>().Add(model);
        }

        /// <summary>
        /// 创建（多个）
        /// </summary>
        /// <param name="modeList">List</param>
        public void Create(List<T> modeList)
        {
            _ljdAppContext.Set<T>().AddRange(modeList);
        }


        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Edit(T model)
        { 
            _ljdAppContext.Entry<T>(model).State = EntityState.Modified;
        }

        /// <summary>
        /// 编辑个别属性
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="propertys">属性数组</param>
        public void Edit(T model, string[] propertys)
        {
            //1 验证
            if (model==null)
            {
                throw  new Exception("实体不能为空！");
            }

            if (propertys.Any()==false)
            {
                throw  new  Exception("要修改的属性至少有一个！");
            }
            _ljdAppContext.Entry<T>(model).State = EntityState.Unchanged;
            //2 将model追加到EF容器 
            foreach (var item in propertys)
            {
                _ljdAppContext.Entry<T>(model).Property(item).IsModified = true;
            }  

        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(T model)
        {
            _ljdAppContext.Set<T>().Remove(model); 
        }

        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <param name="whereLambda"></param>
        public void Delete(Expression<Func<T, bool>> whereLambda)
        {
            var deleteList = GetList().Where(whereLambda).ToList();
            foreach (var entity in deleteList)
            {
                Delete(entity);
            }
        }

        /// <summary>
        /// 搜索所有数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetList()
        {
            return _ljdAppContext.Set<T>();
        }
        /// <summary>
        /// 按条件搜索
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return _ljdAppContext.Set<T>().Where(whereLambda).AsQueryable();
        }
        /// <summary>
        /// 分页查询 排序
        /// </summary> 
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="total">满足条件总条数</param>
        /// <param name="whereLambda">条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderByLambda">排序字段</param>
        /// <returns></returns>
        public IQueryable<T> GetList<TS>(int pageIndex, int pageSize, out int total
            , Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, TS>> orderByLambda)
        {
            var queryable = _ljdAppContext.Set<T>().Where(whereLambda);
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
    }
}