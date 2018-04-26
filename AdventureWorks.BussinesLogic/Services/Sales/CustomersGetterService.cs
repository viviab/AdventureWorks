using System;
using System.Collections.Generic;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.UI.ViewEntities.Sales;
using AdventureWorks.Core.Mappers.Sales;
using AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales;

namespace AdventureWorks.BussinesLogic.Services.Sales
{
    public class CustomersGetterService : ICustomersGetterService
    {
        private readonly ICustomersRepository _customerRepository;

        public CustomersGetterService(ICustomersRepository customerRepository)
        {
            if (customerRepository == null)
                throw new ArgumentNullException(nameof(customerRepository));

            _customerRepository = customerRepository;
        }

        public CustomerViewEntity GetById(int customerId)
        {
            var customer = _customerRepository.GetById(customerId);
            return CustomersMapper.MapTo(customer);
        }

        public IEnumerable<CustomerViewEntity> GetAll()
        {
            var customers = _customerRepository.GetAll();
            return CustomersMapper.MapTo(customers);
        }
    }
}
