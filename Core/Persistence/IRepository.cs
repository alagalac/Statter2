using Core.Models;
using System.Linq;

namespace Core.Persistence
{
    public interface IRepository
    {
        void Delete<T>(T entity) where T : Entity;

        T Get<T>(int id) where T : Entity;

        IQueryable<T> GetAll<T>() where T : Entity;

        void SaveOrUpdate<T>(T entity) where T : Entity;
    }
}