using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingApp.CoreLayer.DataAccessLayer;
using ShoppingApp.CoreLayer.EntitiesLayer;
using ShoppingApp.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShoppingApp.DataAccessLayer.Abstract
{
    public class BaseDataAccess<T> : ICoreDataAccess<T> where T : CoreEntity
    {
        private RepositoryContext _context;

        public BaseDataAccess()
        {
            _context = new RepositoryContext();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            Save();
        }

        public void Add(List<T> items)
        {
            _context.Set<T>().AddRange(items);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Any(exp);
        }

        public List<T> GetActive()
        {
            return _context
                .Set<T>()
                .Where(x => x.Status == Status.Active ||
                            x.Status == Status.Updated)
                .ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetByID(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public void Remove(T item)
        {
            item.Status = Status.Deleted;
            Save();
        }

        public void Remove(Guid id)
        {
            T item = GetByID(id);
            item.Status = Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Status.Deleted;
                Update(item);
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(T item)
        {
            T itemToBeUpdated = GetByID(item.ID);
            EntityEntry entry = _context.Entry(itemToBeUpdated);
            entry.CurrentValues.SetValues(item);
            Save();
        }
    }
}
