using AdventureWorks.Core.Entities.EF;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

namespace AdventureWorks.Core.Persistance.Context
{
    public class AdventureWorksContext : DbContext
    {
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Person> People { get; set; }
        public IDbSet<Store> Stores { get; set; }

        public AdventureWorksContext() : base("Name=AdventureWorksContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbEntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class
        {
            return Entry(entity);
        }

        public DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var errorList = string.Join("\n", e.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors).Select(ve => ve.ErrorMessage));
                throw new ApplicationException("DbEntityValidationException thrown during SaveChanges: " + errorList, e);
            }
        }
    }



}
