using System.Threading.Tasks;

namespace LJD.App.Repository.IUnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}