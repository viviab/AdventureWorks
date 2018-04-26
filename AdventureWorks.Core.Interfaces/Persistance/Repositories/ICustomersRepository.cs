using System.Collections.Generic;
using AdventureWorks.Core.Entities.DTO;
using AdventureWorks.Core.Entities.EF;

namespace AdventureWorks.Core.Interfaces.Persistance.Repositories
{
    public interface ICustomersRepository
    {
        void Add(Customer entity);
        CustomerDTO GetById(int customerId);
        IEnumerable<CustomerDTO> GetAll();
    }
}
