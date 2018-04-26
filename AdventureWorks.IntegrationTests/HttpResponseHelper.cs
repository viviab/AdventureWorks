using System.Net.Http;
using Newtonsoft.Json;

namespace AdventureWorks.IntegrationTests
{
    public static class HttpResponseHelper
    {
        public static T GetReponse<T>(HttpContent content)
        {
            var jsonString = content.ReadAsStringAsync();
            jsonString.Wait();
            return JsonConvert.DeserializeObject<T>(jsonString.Result);
        }
    }
}
