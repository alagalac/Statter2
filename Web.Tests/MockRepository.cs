using Core.Models;
using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Tests
{
    public class MockRepository : IRepository
    {
        public Dictionary<Type, IList<Entity>> Items = new Dictionary<Type, IList<Entity>>();

        public void Delete<T>(T entity) where T : Entity
        {
            if (Items.ContainsKey(typeof(T)))
            {
                Items[typeof(T)].Remove(entity);
            }
            else
            {
                throw new ApplicationException("Unable to delete entity. The type does not exist. Type: " + typeof(T));
            }
        }

        public T Get<T>(int id) where T : Entity
        {
            if (Items.ContainsKey(typeof(T)))
            {
                var item = Items[typeof(T)].FirstOrDefault(x => x.Id == id);
                return (T)item; // I know the items is of type T.
            }
            else
            {
                throw new ApplicationException("Unable to return entity. The type does not exist. Type: " + typeof(T));
            }
        }

        public IQueryable<T> GetAll<T>() where T : Entity
        {
            if (Items.ContainsKey(typeof(T)))
            {
                var items = Items[typeof(T)];
                var result = new List<T>();
                foreach (var item in items)
                {
                    // I know that all of the items in this list are of type T, so can cast to T.
                    result.Add((T)item);
                }

                return result.AsQueryable();
            }
            else
            {
                throw new ApplicationException("Unable to return entities. The type does not exist. Type: " + typeof(T));
            }
        }

        public void SaveOrUpdate<T>(T entity) where T : Entity
        {
            if (Items.ContainsKey(typeof(T)))
            {
                var item = Items[typeof(T)].FirstOrDefault(x => x.Id == entity.Id);
                if (item == null)
                {
                    // It's a new item.
                    Items[typeof(T)].Add(entity);
                }
                else
                {
                    // Swap item.
                    var index = Items[typeof(T)].IndexOf(item);
                    Items[typeof(T)][index] = entity;
                }
            }
            else
            {
                // It's a new type.
                Items[typeof(T)] = new List<Entity>();
                Items[typeof(T)].Add(entity);
            }
        }
    }
}