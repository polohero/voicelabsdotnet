using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace VoiceLabs.Client
{
    public class Client : AnalyticsClientBase
    {

        public Client() { }

        public void Process(AnalyticsRequest request)
        {
            var response = process(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                ToApplicationException(response);
            }
        }

        private Task<HttpResponseMessage> process(AnalyticsRequest request)
        {
            return GetHttpClient().PostAsJsonAsync(
                string.Format("?sdk=n_1&auth_token={0}", request.AppToken), request);
        }
    }
}
