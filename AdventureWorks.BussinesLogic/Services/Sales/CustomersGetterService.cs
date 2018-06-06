using AdventureWorks.Core.Entities.DTO;
using AdventureWorks.Core.Entities.EF;
using AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.Core.Mappers.Sales;
using AdventureWorks.UI.ViewEntities.Sales;
using System;
using System.Collections.Generic;

namespace AdventureWorks.BussinesLogic.Services.Sales
{
    public class CustomersGetterService : ICustomersGetterService
    {
        private readonly ICustomersRepository _customerRepository;
        private readonly IPeopleRepository _peopleRepository;
        private readonly IStoreRepository _storeRepository;

        public CustomersGetterService(ICustomersRepository customerRepository, IPeopleRepository peopleRepository, IStoreRepository storeRepository)
        {
            if (customerRepository == null)
                throw new ArgumentNullException(nameof(customerRepository));
            if (peopleRepository == null)
                throw new ArgumentException(nameof(peopleRepository));
            if (storeRepository == null)
                throw new ArgumentException(nameof(storeRepository));

            _customerRepository = customerRepository;
            _peopleRepository = peopleRepository;
            _storeRepository = storeRepository;
        }

        public CustomerViewEntity GetById(int customerId)
        {
            CustomerDTO customerDTO = new CustomerDTO();

            var customer = _customerRepository.GetById(customerId);

            var people = _peopleRepository.GetById((int)customer.PersonId);

            var stores = _storeRepository.GetById((int)customer.StoreId);

            customerDTO = new CustomerDTO()
            {
                CustomerId = customer.CustomerId,
                FirstName = people.FirstName,
                LastName = people.MiddleName,
                StoreName = stores.Name,
                Title = people.Title
            };

            return CustomersMapper.MapTo(customerDTO);
        }

        public IEnumerable<CustomerViewEntity> GetAll()
        {
            IEnumerable<CustomerDTO> customerDTO = new List<CustomerDTO>();

            var customers = _customerRepository.GetAll();
            foreach (Customer customer in customers)
            {
                var people = _peopleRepository.GetById((int)customer.PersonId);

                var stores = _storeRepository.GetById((int)customer.StoreId);

                var newcustomer = new CustomerDTO()
                {
                    CustomerId = customer.CustomerId,
                    FirstName = people.FirstName,
                    LastName = people.MiddleName,
                    StoreName = stores.Name,
                    Title = people.Title
                };
            }



            return CustomersMapper.MapTo(customerDTO);
        }
    }
}
