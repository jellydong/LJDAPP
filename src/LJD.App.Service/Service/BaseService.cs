using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LJD.App.Repository.IRepository;

namespace LJD.App.Service.Service
{
    public class BaseService<T> where T : class,new() 
    {
        private readonly IBaseRepository<T> _iBaseRepository;

        public BaseService(IBaseRepository<T> iBaseRepository)
        {
            _iBaseRepository = iBaseRepository;
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model">实体对象</param>
        public virtual void Create(T model)
        {
            _iBaseRepository.Create(model);
        }
        /// <summary>
        /// 创建（多个）
        /// </summary>
        /// <param name="modeList">List</param>
        public virtual void Create(List<T> modeList)
        {
            _iBaseRepository.Create(modeList);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param> 
        public virtual void Edit(T model)
        {
            _iBaseRepository.Edit(model);
        }
        /// <summary>
        /// 修改个别属性
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="propertys">属性数组</param>
        public virtual void Edit(T model, string[] propertys)
        {
            _iBaseRepository.Edit(model,propertys);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>  
        public virtual void Delete(T model)
        {
            _iBaseRepository.Delete(model);
        }
        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <param name="whereLambda"></param>
        public virtual void Delete(Expression<Func<T, bool>> whereLambda)
        {
            _iBaseRepository.Delete(whereLambda);
        }
        /// <summary>
        /// 按条件搜索
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return _iBaseRepository.GetList(whereLambda);
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
        public virtual IQueryable<T> GetList<TS>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, TS>> orderByLambda)
        {
            return _iBaseRepository.GetList(pageIndex, pageSize, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}