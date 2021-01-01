using System.Collections.Generic;

namespace Core
{
    /*
     * Notes:
     * ------
     * 1. For Entity Frameword instead of using ListContext we use DbContext of EFCore.
     * 2. In real implementation use IRepository pattern of DevSkill.
     * 3. Just a basic implementation for maintaining  DevSkill structure.
     * **/
    public interface IRepository<TEntity, TContext> 
        where TEntity : class, IEntity
        where TContext : ListContext //Replace ListContext with DbContext for EFCore
    {
        TEntity Add(TEntity item);
        TEntity Edit(TEntity item);
        bool Delete(TEntity item);
        TEntity Get(int id);
        List<TEntity> GetAll();
    }
}
