using System;
using System.Collections.Generic;

namespace AdventureWorks.Core.Interfaces.Persistance
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate = null);

        TEntity GetById(string id);

        TEntity GetById(int id);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Edit(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
