using System;
using Ly.Admin.Data.EF.Database;
using Ly.Admin.IRepositories;
using Ly.Admin.Model;

namespace Ly.Admin.Repositories
{
    public class UserRepository:BaseRepository<SysUser>,IUserRepository
    {
        private readonly LyAdminDbContext _lyAdminDbContext;

        public UserRepository(LyAdminDbContext lyAdminDbContext) : base(lyAdminDbContext)
        {
            _lyAdminDbContext = lyAdminDbContext ?? throw new ArgumentNullException(nameof(lyAdminDbContext));
        }

        public string HelloWorld()
        {
            return "HelloWorld";
        }
    }
}