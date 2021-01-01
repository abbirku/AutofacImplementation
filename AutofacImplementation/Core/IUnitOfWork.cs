using System;

namespace Core
{
    //Just a basic implementation for maintaining structure
    public interface IUnitOfWork /*: IDisposable*/ //We, Need disposable for EFCore but not here
    {
        int SaveChanges();
    }
}
