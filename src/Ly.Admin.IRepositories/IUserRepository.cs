using Ly.Admin.Model;

namespace Ly.Admin.IRepositories
{
    public interface IUserRepository:IBaseRepository<SysUser>
    {
        string HelloWorld();
    }
}