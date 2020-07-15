using System.Net.Http;
using YouTubeFetcher.Core.Factories.Interfaces;

namespace YouTubeFetcher.Core.Factories
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient()
        {
            return new HttpClient();
        }
    }
}
