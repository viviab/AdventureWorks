using AdventureWorks.Core.Entities.DTO;
using AdventureWorks.Core.Entities.EF;
using AdventureWorks.UI.ViewEntities.Sales;
using AutoMapper;

namespace AdventureWorks.Core.Mappers.Sales
{
    public class CustomersMapProfile : Profile
    {
        public CustomersMapProfile()
        {
            CreateMap<CustomerDTO, CustomerViewEntity>();
            CreateMap<CustomerRequest, Customer>();
        }
    }
}
