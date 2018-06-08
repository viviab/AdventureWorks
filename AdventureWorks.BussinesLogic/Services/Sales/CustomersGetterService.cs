using AdventureWorks.Core.Entities.DTO;
using AdventureWorks.Core.Entities.EF;
using AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.Core.Mappers.Sales;
using AdventureWorks.UI.ViewEntities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;

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

            Core.Entities.EF.Person person = null;
            Core.Entities.EF.Store store = null;
            if (customer.PersonId != null)
                person = _peopleRepository.GetById((int)customer.PersonId);
            if (customer.StoreId != null)
                store = _storeRepository.GetById((int)customer.StoreId);

            customerDTO = new CustomerDTO()
            {
                CustomerId = customer.CustomerId,
                FirstName = person?.FirstName,
                MiddleName = person?.MiddleName,
                LastName = person?.LastName,
                StoreName = store?.Name,
                Title = person?.Title
            };

            return CustomersMapper.MapTo(customerDTO);
        }

        public IEnumerable<CustomerViewEntity> GetAll(int? numberOfResult = null)
        {
            List<CustomerDTO> customerDTO = new List<CustomerDTO>();

            var customers = numberOfResult == null ? _customerRepository.GetAll() : _customerRepository.GetAll().Take((int)numberOfResult);
            foreach (Customer customer in customers)
            {
                Core.Entities.EF.Person people = null;
                Core.Entities.EF.Store stores = null;
                if (customer.PersonId != null)
                    people = _peopleRepository.GetById((int)customer.PersonId);

                if (customer.StoreId != null)
                    stores = _storeRepository.GetById((int)customer.StoreId);

                var newcustomer = new CustomerDTO()
                {
                    CustomerId = customer.CustomerId,
                    FirstName = people?.FirstName,
                    LastName = people?.MiddleName,
                    StoreName = stores?.Name,
                    Title = people?.Title
                };
                customerDTO.Add(newcustomer);
            }

            return CustomersMapper.MapTo(customerDTO);
        }
    }
}
