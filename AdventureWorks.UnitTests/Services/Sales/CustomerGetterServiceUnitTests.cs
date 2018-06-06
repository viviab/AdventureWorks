using AdventureWorks.BussinesLogic.Services.Sales;
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

            _peopleGetterService = new CustomersGetterService(new CustomerStubRepository(),new PeopleStubRepository(),new StoreStubRepository());
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

        private class CustomerStubRepository : ICustomersRepository
        {

            public void Add(Customer entity)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Customer> GetAll(Func<Customer, bool> predicate = null)
            {
                throw new NotImplementedException();
            }

            public Customer GetById(string id)
            {
                throw new NotImplementedException();
            }

            public Customer GetById(int id)
            {
                return new Fixture().Create<Customer>();
            }

            public void Delete(Customer entity)
            {
                throw new NotImplementedException();
            }

            public void Edit(Customer entity)
            {
                throw new NotImplementedException();
            }

            public void AddRange(IEnumerable<Customer> entities)
            {
                throw new NotImplementedException();
            }

            public void DeleteRange(IEnumerable<Customer> entities)
            {
                throw new NotImplementedException();
            }
        }

        private class StoreStubRepository : IStoreRepository
        {
            public void Add(Store entity)
            {
                throw new NotImplementedException();
            }

            public void AddRange(IEnumerable<Store> entities)
            {
                throw new NotImplementedException();
            }

            public void Delete(Store entity)
            {
                throw new NotImplementedException();
            }

            public void DeleteRange(IEnumerable<Store> entities)
            {
                throw new NotImplementedException();
            }

            public void Edit(Store entity)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Store> GetAll(Func<Store, bool> predicate = null)
            {
                throw new NotImplementedException();
            }

            public Store GetById(string id)
            {
                throw new NotImplementedException();
            }

            public Store GetById(int id)
            {
                throw new NotImplementedException();
            }
        }

        private class PeopleStubRepository : IPeopleRepository
        {
            public void Add(Person entity)
            {
                throw new NotImplementedException();
            }

            public void AddRange(IEnumerable<Person> entities)
            {
                throw new NotImplementedException();
            }

            public void Delete(Person entity)
            {
                throw new NotImplementedException();
            }

            public void DeleteRange(IEnumerable<Person> entities)
            {
                throw new NotImplementedException();
            }

            public void Edit(Person entity)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Person> GetAll(Func<Person, bool> predicate = null)
            {
                throw new NotImplementedException();
            }

            public Person GetById(string id)
            {
                throw new NotImplementedException();
            }

            public Person GetById(int id)
            {
                throw new NotImplementedException();
            }
        }
    }
}
