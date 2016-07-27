using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence
{
    public class EntityFrameworkRepository : IRepository
    {
        private Context _context;

        public EntityFrameworkRepository(Context context)
        {
            _context = context;
        }

        public T Get<T>(int id) where T : Entity
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>();
        }

        public void SaveOrUpdate<T>(T entity) where T : Entity
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<T>().Add(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}