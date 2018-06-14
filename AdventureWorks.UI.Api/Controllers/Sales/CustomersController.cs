using AdventureWorks.Core.Infrastructure;
using AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales;
using AdventureWorks.UI.ViewEntities.Sales;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AdventureWorks.UI.Api.Controllers.Sales
{

    public class CustomersController : ApiController
    {
        private readonly ICustomersGetterService _customersService;
        private readonly ICustomersAdderService _customersAdderService;
        private readonly IRequestValidationService _requestValidationService;

        public CustomersController(ICustomersGetterService customersServices, ICustomersAdderService customersAdderService, IRequestValidationService requestValidationService)
        {
            if (customersServices == null) throw new ArgumentNullException(nameof(customersServices));
            if (customersAdderService == null) throw new ArgumentNullException(nameof(customersAdderService));
            if (requestValidationService == null) throw new ArgumentNullException(nameof(requestValidationService));
            _customersService = customersServices;
            _customersAdderService = customersAdderService;
            _requestValidationService = requestValidationService;
        }

        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll(int? numberOfResult = null)
        {
            if (!_requestValidationService.IsValidRequest(HttpContext.Current))
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            var customers = _customersService.GetAll(numberOfResult).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        [HttpGet]
        [Route("GetById")]
        public HttpResponseMessage GeyById(int customerId)
        {
            var customer = _customersService.GetById(customerId);
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        [HttpPost]
        public HttpResponseMessage Add(CustomerRequest request)
        {
            var customerId = _customersAdderService.Add(request);
            return Request.CreateResponse(HttpStatusCode.OK, customerId);
        }
    }
}
