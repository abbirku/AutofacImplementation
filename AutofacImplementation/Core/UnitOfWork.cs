using System;

namespace Core
{
    /*
     * Notes:
     * ------
     * 1. In real implementation, implement "SaveChanges()" and "Task<int> SaveChangesAsync();" in UnitOfWork.
     *    The Sample code is given below:-
     *    ------------------------------------
          protected readonly DbContext _dbContext;

          public UnitOfWork(DbContext dBContext) => _dbContext = dBContext;

          public int SaveChanges() => (int)_dbContext?.SaveChanges();

          public async Task<int> SaveChangesAsync() => await _dbContext?.SaveChangesAsync();

          public void Dispose()
          {
              _dbContext.Dispose();
              GC.SuppressFinalize(this);
          }
     *    ------------------------------------
     * 2. Just a basic implementation for maintaining  DevSkill structure.
     * **/
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
