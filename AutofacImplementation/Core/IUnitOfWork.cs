using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
