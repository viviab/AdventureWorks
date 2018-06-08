using AdventureWorks.BussinesLogic.Services.Sales;
using AdventureWorks.Core.Entities.EF;
using AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.UI.Api;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;

namespace AdventureWorks.UnitTests.Services.Sales
{
    [TestFixture]
    public class CustomerGetterServiceUnitTests
    {
        private ICustomersGetterService _peopleGetterService;

        [SetUp]
        public void Setup()
        {

            _peopleGetterService = new CustomersGetterService(new CustomerStubRepository(), new PeopleStubRepository(), new StoreStubRepository());
            MappingConfiguration.Start();
        }

        [Test]
        public void When_CallGetById_ThenReturnValue()
        {
            //Arrange
            var personId = new Fixture().Create<int>();

            //Act
            var person = _peopleGetterService.GetById(personId);

            //Assert 
            person.Should().NotBeNull("Person is Null");
            person.FirstName.Should().NotBeEmpty("Person.FirstName is empty");
            person.LastName.Should().NotBeEmpty("Person.LastName is empty");
            person.MiddleName.Should().NotBeEmpty("Person.MiddleName is empty");
        }

        private class CustomerStubRepository : StubRepository<Customer>, ICustomersRepository
        {

            public override Customer GetById(int id)
            {
                return new Fixture().Create<Customer>();
            }
        }

        private class StoreStubRepository : StubRepository<Store>, IStoreRepository
        {
            public override Store GetById(int id)
            {
                return new Fixture().Create<Store>();
            }

        }

        private class PeopleStubRepository : StubRepository<Person>, IPeopleRepository
        {
            public override Person GetById(int id)
            {
                return new Fixture().Create<Person>();
            }

        }
    }
}
