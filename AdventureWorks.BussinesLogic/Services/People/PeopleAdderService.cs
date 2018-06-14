using AdventureWorks.Core.Interfaces.BussinesLogic.Services.People;
using AdventureWorks.Core.Interfaces.Persistance;
using AdventureWorks.Core.Mappers;
using AdventureWorks.UI.ViewEntities.People;
using System;

namespace AdventureWorks.BussinesLogic.Services.Person
{
    public class PeopleAdderService : IPeopleAdderService
    {
        private readonly IGenericUoW _uow;
        public PeopleAdderService(IGenericUoW uow)
        {
            if (uow == null)
                throw new ArgumentNullException(nameof(uow));

            _uow = uow;
        }

        public int Add(PersonRequest personRequest)
        {
            if (!personRequest.HasCompleteName())
                throw new ArgumentException($"Person has not valid complete name.");

            if (!personRequest.IsAdult())
                throw new ArgumentException("Person is not an adult");

            var person = PeopleMapper.MapTo(personRequest);

            var personRepository = _uow.GetPeopleRepository();

            personRepository.Add(person);

            _uow.SaveChanges();

            return person.BusinessEntityId;
        }
    }
}
