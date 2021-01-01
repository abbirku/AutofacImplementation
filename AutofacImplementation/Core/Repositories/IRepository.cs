using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        T Add(T item);
        T Edit(T item);
        bool Delete(int id);
        T Get(int id);
        List<T> GetAll();
    }
}
