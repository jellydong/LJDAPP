using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ly.Admin.IRepositories;
using Ly.Admin.Model;

namespace Ly.Admin.Services
{
    public class BaseService<T> where T : Entity, new()
    {
        private readonly IBaseRepository<T> _iBaseRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        public BaseService(IBaseRepository<T> iBaseRepository, IUnitOfWork iUnitOfWork)
        {
            _iBaseRepository = iBaseRepository ?? throw new ArgumentNullException(nameof(iBaseRepository));
            _iUnitOfWork = iUnitOfWork ?? throw new ArgumentNullException(nameof(iUnitOfWork));
        }

        public void Insert(T model)
        {
            _iBaseRepository.Insert(model);
        }

        public void Insert(IEnumerable<T> modeList)
        {
            _iBaseRepository.Insert(modeList);
        }

        public void Update(T model)
        {
            _iBaseRepository.Update(model);
        }

        public void Update(T model, List<string> properties)
        {
            _iBaseRepository.Update(model, properties);
        }

        public void Delete(T model)
        {
            _iBaseRepository.Delete(model);
        }

        public void Delete(Expression<Func<T, bool>> whereLambda)
        {
            _iBaseRepository.Delete(whereLambda);
        }
        public T? GetEntity(int id)
        {
            return _iBaseRepository.GetEntity(id);
        }
        public T? GetEntity(Expression<Func<T, bool>> whereLambda)
        {
            return _iBaseRepository.GetEntity(whereLambda);
        }
        public IQueryable<T> GetList()
        {
            return _iBaseRepository.GetList();
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return _iBaseRepository.GetList(whereLambda);
        }

        public IQueryable<T> GetList<TS>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, bool isAsc,
            Expression<Func<T, TS>> orderByLambda)
        {
            return _iBaseRepository.GetList(pageIndex, pageSize, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}