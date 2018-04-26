using AdventureWorks.Core.Interfaces.BussinesLogic.Services.People;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.UI.ViewEntities.People;
using AutoFixture;
using NUnit.Framework;
using System;
using AdventureWorks.BussinesLogic.Services.Person;
using Moq;
using FluentAssertions;
using AdventureWorks.Core.Entities.EF;

namespace AdventureWorks.UnitTests.Services.People
{
    [TestFixture]
    public class PeopleServicesUnitTests
    {

        private IPeopleAdderService _peopleServiceAdder;
        private Mock<IPeopleRepository> _peopleRepository;

        [SetUp]
        public void Setup()
        {
            _peopleRepository = new Mock<IPeopleRepository>();
            _peopleServiceAdder = new PeopleAdderService(_peopleRepository.Object);
        }

        [Test]
        public void When_AddPersonNotAdult_ExpectException()
        {

            //Arrange 
            var fixture = new Fixture();
            var person = fixture.Build<PersonRequest>()
                .Without(p => p.DateOfBirth)
                .Create();

            person.DateOfBirth = DateTime.Now.AddYears(-17);

            //Act
            Action act = () =>  _peopleServiceAdder.Add(person);

            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("Person is not an adult");
            _peopleRepository.Verify(p => p.Add(It.IsAny<Person>()), Times.Never());

        }
    }
}
