using System.Threading.Tasks;

namespace Ly.Admin.IRepositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}