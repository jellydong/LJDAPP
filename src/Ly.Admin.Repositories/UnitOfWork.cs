using System;
using System.Threading.Tasks;
using Ly.Admin.Data.EF.Database;
using Ly.Admin.IRepositories;

namespace Ly.Admin.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly LyAdminDbContext _lyAdminDbContext;

        public UnitOfWork(LyAdminDbContext lyAdminDbContext)
        {
            _lyAdminDbContext = lyAdminDbContext ?? throw new ArgumentNullException(nameof(lyAdminDbContext));
        }
        public Task<int> SaveChangesAsync()
        {
            return _lyAdminDbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _lyAdminDbContext.SaveChanges();
        }
    }
}