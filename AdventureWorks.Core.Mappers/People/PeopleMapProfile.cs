using AdventureWorks.Core.Entities.EF;
using AdventureWorks.UI.ViewEntities.People;
using AutoMapper;

namespace AdventureWorks.Core.Mappers.People
{
    public class PeopleMapProfile : Profile
    {
        public PeopleMapProfile()
        {
            CreateMap<Person, PersonRequest>();
            CreateMap<PersonRequest, Person>();
        }
    }
}
