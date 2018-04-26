using System.Collections.Generic;
using System.Linq;
using AdventureWorks.Core.Entities.DTO;
using AdventureWorks.Core.Entities.EF;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.Core.Persistance.Context;

namespace AdventureWorks.Core.Persistance.Repositories.Sales
{
    public class CustomersRepository : Repository<Customer>, ICustomersRepository
    {
        public CustomersRepository(AdventureWorksContext dbContext) : base(dbContext)
        {
        }

        public CustomerDTO GetById(int customerId)
        {
            var result = from c in DbContext.Customers
                join p in DbContext.People on c.PersonId equals p.BusinessEntityId
                join s in DbContext.Stores on c.StoreId equals s.BusinessEntityId
                where (c.CustomerId == customerId)
                select new CustomerDTO()
                {
                    CustomerId = c.CustomerId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    MiddleName = p.MiddleName,
                    StoreName = s.Name,
                    Title = p.Title
                };

            return result.SingleOrDefault();
        }

        public new IEnumerable<CustomerDTO> GetAll()
        {
            var result = from c in DbContext.Customers
                join p in DbContext.People on c.PersonId equals p.BusinessEntityId
                join s in DbContext.Stores on c.StoreId equals s.BusinessEntityId
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
