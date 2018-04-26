using AdventureWorks.Core.Interfaces.BussinesLogic.Services.People;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.Core.Mappers;
using AdventureWorks.UI.ViewEntities.People;
using System;

namespace AdventureWorks.BussinesLogic.Services.Person
{
    public class PeopleAdderService : IPeopleAdderService
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleAdderService(IPeopleRepository peopleRepository)
        {
            if (peopleRepository == null)
                throw new ArgumentNullException(nameof(peopleRepository));

            _peopleRepository = peopleRepository;
        }

        public int Add(PersonRequest personRequest)
        {
            if (!personRequest.HasCompleteName())
                throw new ArgumentException($"Person has not valid complete name.");

            if (!personRequest.IsAdult())
                throw new ArgumentException("Person is not an adult");

            var person = PeopleMapper.MapTo(personRequest);
            _peopleRepository.Add(person);
            return person.BusinessEntityId;
        }
    }
}
