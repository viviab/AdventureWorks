using System.Collections.Generic;
using AdventureWorks.Core.Entities.DTO;
using AdventureWorks.Core.Entities.EF;
using AdventureWorks.UI.ViewEntities.Sales;
using AutoMapper;

namespace AdventureWorks.Core.Mappers.Sales
{
    public static class CustomersMapper
    {
        public static CustomerViewEntity MapTo(CustomerDTO customer)
        {
            return Mapper.Map<CustomerDTO, CustomerViewEntity>(customer);
        }
        public static IEnumerable<CustomerViewEntity> MapTo(IEnumerable<CustomerDTO> customers)
        {
            return Mapper.Map<IEnumerable<CustomerDTO>, IEnumerable<CustomerViewEntity>>(customers);
        }

        public static Customer MapTo(CustomerRequest customer)
        {
            return Mapper.Map<CustomerRequest, Customer>(customer);
        }
    }
}
