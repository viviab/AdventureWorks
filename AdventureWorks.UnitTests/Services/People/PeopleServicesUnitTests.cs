using AdventureWorks.BussinesLogic.Services.Person;
using AdventureWorks.Core.Entities.EF;
using AdventureWorks.Core.Interfaces.BussinesLogic.Services.People;
using AdventureWorks.Core.Interfaces.Persistance;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.UI.Api;
using AdventureWorks.UI.ViewEntities.People;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

namespace AdventureWorks.UnitTests.Services.People
{
    [TestFixture]
    public class PeopleServicesUnitTests
    {

        private IPeopleAdderService _peopleServiceAdder;
        private Mock<IPeopleRepository> _peopleRepository;
        private Mock<IGenericUoW> _mockUoW;

        [SetUp]
        public void Setup()
        {

            _peopleRepository = new Mock<IPeopleRepository>();
            _mockUoW = new Mock<IGenericUoW>();
            _mockUoW.Setup(m => m.GetPeopleRepository()).Returns(_peopleRepository.Object);
            _peopleServiceAdder = new PeopleAdderService(_mockUoW.Object);

            MappingConfiguration.Start();
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
            Action act = () => _peopleServiceAdder.Add(person);

            //Assert
            act.Should().Throw<ArgumentException>().WithMessage("Person is not an adult");
            _peopleRepository.Verify(p => p.Add(It.IsAny<Person>()), Times.Never());

        }

        [Test]
        public void When_AddPersonAdult()
        {
            var fixture = new Fixture();
            var person = fixture.Build<PersonRequest>()
                .Create();

            person.DateOfBirth = DateTime.Now.AddYears(-18).AddMinutes(-1);
            //Act
            Action act = () => _peopleServiceAdder.Add(person);

            //Assert
            act.Should().NotThrow<ArgumentException>();
            _peopleRepository.Verify(p => p.Add(It.IsAny<Person>()), Times.Once());
            _mockUoW.Verify(p => p.GetPeopleRepository(), Times.Once());

        }
    }
}
