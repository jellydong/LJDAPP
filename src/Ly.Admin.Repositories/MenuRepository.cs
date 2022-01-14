using Ly.Admin.Data.EF.Database;
using Ly.Admin.IRepositories;
using Ly.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.Repositories
{
    public class MenuRepository : BaseRepository<SysMenu>, IMenuRepository
    {
        public MenuRepository(LyAdminDbContext lyAdminDbContext) : base(lyAdminDbContext)
        {
        }
    }
}
