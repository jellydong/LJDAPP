using System.Threading.Tasks;
using LJD.App.Model.DbModels;
using LJD.App.Repository.IUnitOfWork;

namespace LJD.App.Service.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LJDAPPContext _ljdAppContext;

        public UnitOfWork(LJDAPPContext ljdAppContext)
        {
            _ljdAppContext = ljdAppContext;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _ljdAppContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return 0;
            //return _ljdAppContext.SaveChanges();
        }
    }
}