using System;
using Ly.Admin.IRepositories;
using Ly.Admin.IServices;
using Ly.Admin.Model;

namespace Ly.Admin.Services
{
    public class PostService : BaseService<Post>, IPostService
    {
        private readonly IPostRepository _iRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        public PostService(IPostRepository iRepository, IUnitOfWork iUnitOfWork) : base(iRepository, iUnitOfWork)
        {
            _iRepository = iRepository ?? throw new ArgumentNullException(nameof(iRepository));
            _iUnitOfWork = iUnitOfWork ?? throw new ArgumentNullException(nameof(iUnitOfWork));
        }
    }
}