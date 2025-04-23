using System.Collections.Generic;

namespace Data.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int Id);
        T Add(T entity);
        T Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
    }
}