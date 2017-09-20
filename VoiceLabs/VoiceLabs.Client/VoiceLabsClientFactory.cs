using System;
using System.Net.Http;

namespace VoiceLabs.Client
{
    public class VoiceLabsClientFactory : HttpClientFactoryBase
    {
        protected override void InitializeHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://api.voicelabs.co/events/");
        }
    }
}
