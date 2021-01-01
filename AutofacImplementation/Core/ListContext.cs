using System.Collections.Generic;

namespace Core
{
    /*
     * Notes:
     * ------
     * 1. Will be single instance through out the application
     * 2. Just a basic implementation for maintaining DevSkill structure.
     * **/
    public class DBSetsCollection
    {
        public IDictionary<string, object> _dbSets;

        public DBSetsCollection()
        {
            _dbSets = new Dictionary<string, object>();
        }

        public IDictionary<string, object> GetDbSets()
        {
            if (_dbSets == null)
                _dbSets = new Dictionary<string, object>();

            return _dbSets;
        }
    }

    public class ListContext
    {
        private readonly IDictionary<string, object> _dbSets;

        public ListContext(DBSetsCollection dBSetsCollection)
        {
            _dbSets = dBSetsCollection.GetDbSets();
        }

        public List<T> Set<T>() where T : IEntity
        {
            var className = typeof(T).Name;

            if (!_dbSets.ContainsKey(className))
            {
                var list = new List<T>();
                _dbSets.Add(className, list);
            }

            return (List<T>)_dbSets[className];
        }

        public List<T> Get<T>() where T : IEntity
        {
            var className = typeof(T).Name;
            var obj = _dbSets[className];

            return (List<T>)obj;
        }

        //Here, SaveChanges just returns 1. Just a basic implementation for maintaining structure.
        public int SaveChanges()
        {
            return 1;
        }
    }
}
