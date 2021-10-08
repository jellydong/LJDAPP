using System;
using Ly.Admin.IRepositories;
using Ly.Admin.IServices;
using Ly.Admin.Model;

namespace Ly.Admin.Services
{
    public class AuthService : BaseService<SysAuth>, IAuthService
    {
        private readonly IAuthRepository _iRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        public AuthService(IAuthRepository iRepository, IUnitOfWork iUnitOfWork) : base(iRepository, iUnitOfWork)
        {
            _iRepository = iRepository ?? throw new ArgumentNullException(nameof(iRepository));
            _iUnitOfWork = iUnitOfWork ?? throw new ArgumentNullException(nameof(iUnitOfWork));
        }
    }
}