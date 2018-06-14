using AdventureWorks.UI.Api.Controllers.Sales;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using System.Net;

namespace AdventureWorks.IntegrationTests.Sales
{
    [TestFixture]
    public class CustomersControllerTestsGetById : ControllerTestBase<CustomersController>
    {
        [Test]
        public void When_GetById_ExistCustomer()
        {
            //Arrange
            var customer = new Fixture().Create<int>();
            //Act
            var responseCustomerAdder = Controller.GeyById(customer);

            //Assert
            responseCustomerAdder.StatusCode.Should().Be(HttpStatusCode.OK, "httpStatusCode is not Ok");

        }
    }
}
