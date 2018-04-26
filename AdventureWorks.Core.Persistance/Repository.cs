using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AdventureWorks.Core.Interfaces.Persistance;
using AdventureWorks.Core.Persistance.Context;

namespace AdventureWorks.Core.Persistance
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AdventureWorksContext DbContext;

        protected Repository(AdventureWorksContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {

            IEnumerable<TEntity> data = DbContext.GetSet<TEntity>().ToList();
            return data;
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {

            IEnumerable<TEntity> data = DbContext.GetSet<TEntity>().Where(predicate).ToList();
            return data;
        }

        public void Add(TEntity entity)
        {
            DbContext.GetSet<TEntity>().Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbContext.GetSet<TEntity>().Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            DbContext.GetEntry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void EditProperty(TEntity entity, string propertyName)
        {
            DbContext.GetSet<TEntity>().Attach(entity);
            DbContext.GetEntry(entity).Property(propertyName).IsModified = true;
            DbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbContext.GetSet<TEntity>().AddRange(entities);
            DbContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            DbContext.GetSet<TEntity>().RemoveRange(entities);
            DbContext.SaveChanges();
        }

    }
}

