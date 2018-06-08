using AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales;
using AdventureWorks.Core.Interfaces.Persistance;
using AdventureWorks.Core.Mappers.Sales;
using AdventureWorks.UI.ViewEntities.Sales;
using System;

namespace AdventureWorks.BussinesLogic.Services.Sales
{
    public class CustomersAdderService : ICustomersAdderService
    {
        private readonly IGenericUoW _uow;

        public CustomersAdderService(IGenericUoW uow)
        {
            if (uow == null) throw new ArgumentNullException(nameof(uow));
            _uow = uow;

        }

        public int Add(CustomerRequest customerRequest)
        {

            if (!customerRequest.PersonId.HasValue && !customerRequest.StoreId.HasValue)
                throw new ArgumentException($"Neither {nameof(customerRequest.PersonId)} nor {nameof(customerRequest.StoreId)} have value");

            var customer = CustomersMapper.MapTo(customerRequest);
            customer.ModifiedDate = DateTime.Now;

            var customerRepository = _uow.GetCustomerRepository();
            customerRepository.Add(customer);
            _uow.SaveChanges();

            return customer.CustomerId;
        }
    }
}
