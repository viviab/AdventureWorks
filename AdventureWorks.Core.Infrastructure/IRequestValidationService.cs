using System.Web;

namespace AdventureWorks.Core.Infrastructure
{
    public interface IRequestValidationService
    {
        bool IsValidRequest(HttpContext context);
    }
}