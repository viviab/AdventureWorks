using NUnit.Framework;
using AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales;
using AutoFixture;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.Core.Entities.DTO;
using AdventureWorks.Core.Entities.EF;
using System;
using System.Collections.Generic;
using AdventureWorks.BussinesLogic.Services.Sales;
using FluentAssertions;
using AdventureWorks.UI.Api;

namespace AdventureWorks.UnitTests.Services.Sales
{
    [TestFixture]
    public class CustomerGetterServiceUnitTests
    {
        private ICustomersGetterService _peopleGetterService;

        [SetUp]
        public void Setup()
        {

            _peopleGetterService = new CustomersGetterService(new CustomerStubRepository());
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
            public CustomerDTO GetById(int customerId)
            {
                return new Fixture().Create<CustomerDTO>();
            }

            public void Add(Customer entity)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<CustomerDTO> GetAll()
            {
                throw new NotImplementedException();
            }

        }

    }
}
