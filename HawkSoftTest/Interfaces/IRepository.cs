using System.Collections.Generic;

namespace HawkSoftTest
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}