using AdventureWorks.Core.Entities.DTO;
using AdventureWorks.Core.Entities.EF;
using System.Collections.Generic;

namespace AdventureWorks.Core.Interfaces.Persistance.Repositories
{
    public interface ICustomersRepository : IGenericRepository<Customer>
    {
        IEnumerable<CustomerDTO> GetAllCustomer();
    }
}
