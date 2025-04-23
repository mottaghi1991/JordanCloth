using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyContext _context;

        public GenericRepository(MyContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
             _context.Set<T>().AddAsync(entity);
             _context.SaveChangesAsync();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                return false;

            _context.Set<T>().Remove(entity);
            _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return  _context.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChangesAsync();
            return entity;
        }
    }
}
