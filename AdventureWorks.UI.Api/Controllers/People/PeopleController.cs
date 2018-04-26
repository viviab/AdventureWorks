using AdventureWorks.Core.Interfaces.BussinesLogic.Services.People;
using AdventureWorks.UI.ViewEntities.People;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventureWorks.UI.Api.Controllers.Person
{
    public class PeopleController : ApiController
    {
        private readonly IPeopleAdderService _peopleAdderService;
        public PeopleController(IPeopleAdderService peopleAdderService)
        {
            if (peopleAdderService == null)
                throw new ArgumentNullException(nameof(peopleAdderService));

            _peopleAdderService = peopleAdderService;
        }

        [HttpPost]
        public HttpResponseMessage Add(PersonRequest request)
        {
            var personId = _peopleAdderService.Add(request);
            return Request.CreateResponse(HttpStatusCode.OK, personId);
        }
    }
}