using System.Collections.Generic;

//Just a basic implementation for maintaining structure

namespace Core
{
    /*
     * Notes:
     * ------
     * 1. For Entity Frameword instead of using ListContext we use DbContext of EFCore
     * 2. In real implementation use Repository pattern of DevSkill
     * 3. Just a basic implementation for maintaining  DevSkill structure.
     * **/
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity, TContext>
        where TEntity : class, IEntity
        where TContext : ListContext //Replace ListContext with DbContext for EFCore
    {
        private readonly TContext _dbContext;
        private readonly List<TEntity> _dbSet;

        public Repository(TContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity item)
        {
            item.Id = _dbSet.Count + 1;
            _dbSet.Add(item);

            return item;
        }

        public bool Delete(TEntity data)
        {
            var index = _dbSet.FindIndex(x => x.Id == data.Id);
            if (index == -1)
                return false;

            _dbSet.RemoveAt(index);
            return true;
        }

        public TEntity Edit(TEntity item)
        {
            var index = _dbSet.FindIndex(x => x.Id == item.Id);
            if (index < 0)
                return null;

            _dbSet[index] = item;
            return item;
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(x => x.Id == id);
        }

        public List<TEntity> GetAll()
        {
            return _dbSet;
        }
    }
}
