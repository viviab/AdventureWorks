using AdventureWorks.Core.Interfaces.Persistance;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.Core.Persistance.Context;
using AdventureWorks.Core.Persistance.Repositories.People;
using AdventureWorks.Core.Persistance.Repositories.Sales;
using AdventureWorks.Core.Persistance.Repositories.Stores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AdventureWorks.Core.Persistance
{
    public class GenericUoW : IGenericUoW
    {
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        readonly AdventureWorksContext entities = null;
        ICustomersRepository customerRepository;
        IPeopleRepository peopleRepository;
        IStoreRepository storeRepository;
        DbContextTransaction transaction = null;
        bool disposed = false;


        public GenericUoW(AdventureWorksContext entities, bool createTransaction = false)
        {
            this.entities = entities;

            if (createTransaction)
            {
                OpenTransaction();
            }

        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            IGenericRepository<TEntity> repo = new GenericRepository<TEntity>(entities);

            repositories.Add(typeof(TEntity), repo);
            return repo;
        }

        public ICustomersRepository GetCustomerRepository()
        {

            if (customerRepository == null)
            {
                customerRepository = new CustomersRepository(entities);
            }

            return customerRepository;

        }

        public IPeopleRepository GetPeopleRepository()
        {

            if (peopleRepository == null)
            {
                peopleRepository = new PeopleRepository(entities);
            }
            return peopleRepository;

        }

        public IStoreRepository GetStoreRepository()
        {
            if (storeRepository == null)
            {
                storeRepository = new StoreRepository(entities);
            }
            return storeRepository;
        }




        public void SaveChanges()
        {

            Exception exception = null;
            try
            {
                entities.SaveChanges();
                this.transaction.Commit();
            }
            catch (Exception e)
            {
                //TODO log in the system
                this.transaction.Rollback();

                //throw controllated exception after the rollback
                throw exception;
            }



        }



        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entities.Dispose();
                }
                //To clean the transaction always do.
                this.transaction?.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            this.transaction?.Dispose();
        }

        ~GenericUoW()
        {
            Dispose(false);
        }

        private void OpenTransaction()
        {

            //if it´s not created yet, start the transaction
            if (this.transaction == null)
            {

                this.transaction = this.entities.Database.BeginTransaction();
            }

        }
    }
}
