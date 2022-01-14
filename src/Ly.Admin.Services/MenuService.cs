using Ly.Admin.IRepositories;
using Ly.Admin.IServices;
using Ly.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.Services
{
    public class MenuService : BaseService<SysMenu>, IMenuService
    {
        private readonly IMenuRepository _iRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        public MenuService(IMenuRepository iRepository, IUnitOfWork iUnitOfWork) : base(iRepository, iUnitOfWork)
        {
            _iRepository = iRepository ?? throw new ArgumentNullException(nameof(iRepository));
            _iUnitOfWork = iUnitOfWork ?? throw new ArgumentNullException(nameof(iUnitOfWork));
        }
    }
}
