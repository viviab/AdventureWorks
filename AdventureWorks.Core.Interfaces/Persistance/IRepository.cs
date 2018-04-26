using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorks.Core.Interfaces.Persistance
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Edit(TEntity entity);

        void EditProperty(TEntity entity, string propertyName);

        void AddRange(IEnumerable<TEntity> entities);

        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
