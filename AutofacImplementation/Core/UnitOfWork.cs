//Just a basic implementation for maintaining structure
namespace Core
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ListContext _listContext;

        public UnitOfWork(ListContext listContext) => _listContext = listContext;

        public int SaveChanges() => _listContext.SaveChanges();
    }
}
