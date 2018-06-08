using System.Collections.Generic;
using System.Linq;
using AdventureWorks.Core.Entities.DTO;
using AdventureWorks.Core.Entities.EF;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.Core.Persistance.Context;

namespace AdventureWorks.Core.Persistance.Repositories.Sales
{
    public class CustomersRepository : GenericRepository<Customer>, ICustomersRepository
    {
        private AdventureWorksContext _entities;

        public CustomersRepository(AdventureWorksContext dbContext) : base(dbContext)
        {
            _entities = dbContext;
        }
    }
}
