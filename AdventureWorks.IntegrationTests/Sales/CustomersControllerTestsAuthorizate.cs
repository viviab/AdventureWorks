using AdventureWorks.UI.Api.Controllers.Sales;
using FluentAssertions;
using NUnit.Framework;
using System.Net;

namespace AdventureWorks.IntegrationTests.Sales
{
    [TestFixture]
    public class CustomersControllerTestsAuthorizate : ControllerTestBase<CustomersController>
    {

        [Test]
        public void When_GetAllCustomer_Authorize()
        {
            //Arrange

            //Act
            var responseCustomerAdder = Controller.GetAll();

            //Assert
            responseCustomerAdder.StatusCode.Should().Be(HttpStatusCode.OK, "httpStatusCode is not Ok");

        }

    }
}

