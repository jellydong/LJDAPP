using System;
using Ly.Admin.Data.EF.Database;
using Ly.Admin.IRepositories;
using Ly.Admin.Model;

namespace Ly.Admin.Repositories
{
    public class PostRepository:BaseRepository<Post>,IPostRepository
    {
        public PostRepository(LyAdminDbContext lyAdminDbContext) : base(lyAdminDbContext)
        {
        }
    }
}