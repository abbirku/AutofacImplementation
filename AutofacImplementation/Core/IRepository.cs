using System.Collections.Generic;

//Just a basic implementation for maintaining structure
namespace Core
{
    /*
     * Note: For Entity Frameword instead of using ListContext we use DbContext of EFCore
     * **/
    public interface IRepository<TEntity, TContext> 
        where TEntity : class, IEntity
        where TContext : ListContext //DbContext
    {
        TEntity Add(TEntity item);
        TEntity Edit(TEntity item);
        bool Delete(TEntity item);
        TEntity Get(int id);
        List<TEntity> GetAll();
    }
}
