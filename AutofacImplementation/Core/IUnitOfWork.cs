using System;

namespace Core
{
    /*
     * Notes:
     * ------
     * 1. In real implementation provide "SaveChanges()" and "Task<int> SaveChangesAsync();" in IUnitOfWork
     * 2. Just a basic implementation for maintaining  DevSkill structure.
     * **/
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
