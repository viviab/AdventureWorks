using AdventureWorks.Core.Entities.DTO;
using AdventureWorks.Core.Entities.EF;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.Core.Persistance.Context;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorks.Core.Persistance.Repositories.Sales
{
    public class CustomersRepository : GenericRepository<Customer>, ICustomersRepository
    {
        private AdventureWorksContext _entities;

        public CustomersRepository(AdventureWorksContext dbContext) : base(dbContext)
        {
            _entities = dbContext;
        }

        public IEnumerable<CustomerDTO> GetAllCustomer()
        {

            var result = from c in _entities.Customers
                         join p in _entities.People on c.PersonId equals p.BusinessEntityId
                         join s in _entities.Stores on c.StoreId equals s.BusinessEntityId
                         select new CustomerDTO()
                         {
                             CustomerId = c.CustomerId,
                             FirstName = p.FirstName,
                             LastName = p.LastName,
                             MiddleName = p.MiddleName,
                             StoreName = s.Name,
                             Title = p.Title
                         };

            return result;
        }


    }
}
