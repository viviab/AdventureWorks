using System.Net;
using System.Transactions;
using AdventureWorks.UI.Api.Controllers.Sales;
using AdventureWorks.UI.ViewEntities.Sales;
using FluentAssertions;
using NUnit.Framework;

namespace AdventureWorks.IntegrationTests.Sales
{

    [TestFixture]
    public class CustomersControllerTestsDisposable : ControllerTestBase<CustomersController>
    {
        private TransactionScope _scope;

        [SetUp]
        public void Setup()
        {
            _scope = new TransactionScope();
        }

        [Test]
        public void When_AddNewCustomerDisposable()
        {
            //Arrange
            var request = new CustomerRequest
            {
                PersonId = 1345, 
                TerritoryId = 4
            };

            //Act
            var responseCustomerAdder = Controller.Add(request);

            //Assert
            responseCustomerAdder.StatusCode.Should().Be(HttpStatusCode.OK, "httpStatusCode is not Ok");

            var customerId = HttpResponseHelper.GetReponse<int>(responseCustomerAdder.Content);
            customerId.Should().BeGreaterThan(0, $"customerId {customerId}: should be greater than 0");

        }

        [TearDown]
        public void Clear()
        {
            _scope.Dispose();
        }
    }
}
