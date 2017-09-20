using System;
using System.Net.Http;

namespace VoiceLabs.Client
{
    public abstract class AnalyticsClientBase
    {
        private VoiceLabsClientFactory _httpClientFactory = new VoiceLabsClientFactory();

        protected HttpClient GetHttpClient()
        {
            return _httpClientFactory.GetHttpClientInstance();
        }

        protected void ToApplicationException(HttpResponseMessage response)
        {
            throw new ApplicationException(string.Format("Call failed to VoiceLabs{0}.  Failure Reason: {1} - {2}"
                , response.RequestMessage.RequestUri, response.StatusCode, response.Content.ReadAsStringAsync().Result));
        }
    }
}
