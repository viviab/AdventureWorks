using System.Web;

namespace AdventureWorks.Core.Infrastructure
{
    public class RequestValidationService : IRequestValidationService
    {
        public bool IsValidRequest(HttpContext context)
        {
            var header = context.Request.Headers["Authorization"];
            return header == "sequel";
        }
    }
}
