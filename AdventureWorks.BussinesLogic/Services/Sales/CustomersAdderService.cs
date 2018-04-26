using System;
using AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.UI.ViewEntities.Sales;
using AdventureWorks.Core.Mappers.Sales;

namespace AdventureWorks.BussinesLogic.Services.Sales
{
    public class CustomersAdderService : ICustomersAdderService
    {
        private readonly ICustomersRepository _customerRepository;

        public CustomersAdderService(ICustomersRepository customerRepository)
        {
            if (customerRepository == null) throw new ArgumentNullException(nameof(customerRepository));
            _customerRepository = customerRepository;

        }

        public int Add(CustomerRequest customerRequest)
        {

            if (!customerRequest.PersonId.HasValue && !customerRequest.StoreId.HasValue)
                throw new ArgumentException($"Neither {nameof(customerRequest.PersonId)} nor {nameof(customerRequest.StoreId)} have value");

            var customer = CustomersMapper.MapTo(customerRequest);
            customer.ModifiedDate = DateTime.Now;

            _customerRepository.Add(customer);
            return customer.CustomerId;
        }
    }
}
