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
        ICustomersRepository userRepository;
        IPeopleRepository planRepository;
        IStoreRepository tokenRepository;
        DbContextTransaction transaction = null;
        bool createTransaction = false;
        bool disposed = false;


        public GenericUoW(AdventureWorksContext entities, bool createTransaction = false)
        {
            this.entities = entities;
            this.transaction = this.entities.Database.CurrentTransaction;
            this.createTransaction = createTransaction;

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

            if (userRepository == null)
            {
                userRepository = new CustomersRepository(entities);
            }

            return userRepository;

        }

        public IPeopleRepository GetPeopleRepository()
        {

            if (planRepository == null)
            {
                planRepository = new PeopleRepository(entities);
            }
            return planRepository;

        }

        public IStoreRepository GetStoreRepository()
        {
            if (tokenRepository == null)
            {
                tokenRepository = new StoreRepository(entities);
            }
            return tokenRepository;
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
            //The user want to create a transaction
            if (this.createTransaction == true)
            {
                //if it´s not created yet, start the transaction
                if (this.transaction == null)
                {

                    this.transaction = this.entities.Database.BeginTransaction();
                }
            }
        }
    }
}
