using System.Net.Http;
using YouTubeFetcher.Core.Factories.Interfaces;

namespace YouTubeFetcher.Core.Factories
{
    /// <summary>
    /// The factory for creating a HttpClient
    /// </summary>
    public class HttpClientFactory : IHttpClientFactory
    {
        /// <summary>
        /// This method creates a client
        /// </summary>
        /// <returns></returns>
        public HttpClient CreateClient()
        {
            return new HttpClient();
        }
    }
}
