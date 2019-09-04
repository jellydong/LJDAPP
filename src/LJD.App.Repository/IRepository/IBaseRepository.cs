using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LJD.App.Repository.IRepository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>成功失败</returns>
        void Create(T model);


        /// <summary>
        /// 创建（多个）
        /// </summary>
        /// <param name="modeList">List</param>
        void Create(List<T> modeList);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Edit(T model);

        /// <summary>
        /// 编辑个别属性
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="propertys">属性数组</param>
        void Edit(T model, string[] propertys);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(T model);

        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda">条件</param>
        void Delete(Expression<Func<T, bool>> whereLambda);


        /// <summary>
        /// 按条件搜索
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda);

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
        IQueryable<T> GetList<TS>(int pageIndex, int pageSize, out int total
            , Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, TS>> orderByLambda);
         

    }
}