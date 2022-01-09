using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter =null); //filter = null -> filtre vermese de olur
        T Get(Expression<Func<T, bool>> filter =null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAllById(int entityId);
    }
}