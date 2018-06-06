using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using System;

namespace AdventureWorks.Core.Interfaces.Persistance
{
    public interface IGenericUoW : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

        void SaveChanges();

        ICustomersRepository GetCustomerRepository();

        IPeopleRepository GetPeopleRepository();

        IStoreRepository GetStoreRepository();

    }
}
