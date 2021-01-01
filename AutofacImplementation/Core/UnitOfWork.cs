//Just a basic implementation for maintaining structure
using System;

namespace Core
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ListContext _listContext;

        public UnitOfWork(ListContext listContext) => _listContext = listContext;

        public int SaveChanges() => _listContext.SaveChanges();

        public void Dispose()
        {
            //_dbContext.Dispose(); //Only Dispose DbContext for EFCore
            GC.SuppressFinalize(this);
        }
    }
}
