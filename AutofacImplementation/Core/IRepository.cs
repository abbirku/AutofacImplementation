using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IRepository<T> where T : IEntity
    {
        T Add(T item);
        T Edit(T item);
        bool Delete(int id);
        T Get(int id);
        List<T> GetAll();
    }
}
