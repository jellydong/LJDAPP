using Ly.Admin.Data.EF.Database;
using Ly.Admin.IRepositories;
using Ly.Admin.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ly.Admin.Repositories
{
    public class AuthRepository : BaseRepository<SysAuth>, IAuthRepository
    {
        public AuthRepository(LyAdminDbContext lyAdminDbContext) : base(lyAdminDbContext)
        {
        }
    }
}
