using ShoppingApp.CoreLayer.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShoppingApp.CoreLayer.DataAccessLayer
{
    public interface ICoreDataAccess<T> where T : CoreEntity
    {
        void Add(T item);
        void Add(List<T> items);
        void Update(T item);
        void Remove(T item);
        List<T> GetActive();
        void Remove(Guid id);
        T GetByID(Guid id);
        int Save();
        void RemoveAll(Expression<Func<T, bool>> exp);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
    }
}
