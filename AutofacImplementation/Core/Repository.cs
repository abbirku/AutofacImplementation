using System.Collections.Generic;

namespace Core
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> list;

        public Repository()
        {
            list = new List<T>();
        }

        public T Add(T item)
        {
            item.Id = list.Count + 1;
            list.Add(item);
            return item;
        }

        public bool Delete(int id)
        {
            var item = list.Find(x => x.Id == id);
            if (item == null)
                return false;

            list.Remove(item);
            return true;
        }

        public T Edit(T item)
        {
            var index = list.FindIndex(x => x.Id == item.Id);
            list[index] = item;
            return item;
        }

        public T Get(int id)
        {
            return list.Find(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return list;
        }
    }
}
