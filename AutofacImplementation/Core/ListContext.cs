using System.Collections.Generic;

//Just a basic implementation for maintaining structure
namespace Core
{
    
    //Will be single instance through out the application
    public class ListContext
    {
        private readonly IDictionary<string, object> _dbSets;

        public ListContext()
        {
            _dbSets = new Dictionary<string, object>();
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

        //Here, SaveChanges returns 1. Just a basic implementation for maintaining structure
        public int SaveChanges()
        {
            return 1;
        }
    }
}
