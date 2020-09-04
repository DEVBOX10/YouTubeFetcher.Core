using System.Net.Http;
using YouTubeFetcher.Core.Factories.Interfaces;

namespace YouTubeFetcher.Core.Factories
{
    /// <inheritdoc/>
    public class HttpClientFactory : IHttpClientFactory
    {
        /// <inheritdoc/>
        public HttpClient CreateClient()
        {
            return new HttpClient();
        }
    }
}
