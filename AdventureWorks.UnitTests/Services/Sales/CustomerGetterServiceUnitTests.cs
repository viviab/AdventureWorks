using AdventureWorks.BussinesLogic.Services.Sales;
using AdventureWorks.Core.Entities.DTO;
using AdventureWorks.Core.Entities.EF;
using AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.UI.Api;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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

        [Test]
        public void When_CallGetByAll_ThenReturnValue()
        {
            //Arrange
            var peopleId = new Fixture().CreateMany<int>();

            var people = _peopleGetterService.GetAll();

            people.Should().NotBeNullOrEmpty("People is empty or null");
            people.Should().HaveSameCount(peopleId);

        }

        private class CustomerStubRepository : StubRepository<Customer>, ICustomersRepository
        {

            public override Customer GetById(int id)
            {
                return new Fixture().Create<Customer>();
            }

            public override IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null)
            {
                return new Fixture().CreateMany<Customer>();
            }

            public IEnumerable<CustomerDTO> GetAllCustomer()
            {
                return new Fixture().CreateMany<CustomerDTO>();
            }


        }

        private class StoreStubRepository : StubRepository<Store>, IStoreRepository
        {
            public override Store GetById(int id)
            {
                return new Fixture().Create<Store>();
            }

            public override IEnumerable<Store> GetAll(Func<Store, bool> predicate = null)
            {
                return new Fixture().CreateMany<Store>();
            }

        }

        private class PeopleStubRepository : StubRepository<Person>, IPeopleRepository
        {
            public override Person GetById(int id)
            {
                return new Fixture().Create<Person>();
            }

            public override IEnumerable<Person> GetAll(Func<Person, bool> predicate = null)
            {
                return new Fixture().CreateMany<Person>();
            }

        }
    }
}
