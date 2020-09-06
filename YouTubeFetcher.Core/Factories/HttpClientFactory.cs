using System.Net.Http;

namespace YouTubeFetcher.Core.Factories
{
    /// <inheritdoc/>
    public class HttpClientFactory : IHttpClientFactory
    {
        private static HttpClient HttpClient { get; set; }

        /// <inheritdoc/>
        public HttpClient CreateClient(string name = "") => HttpClient ??= new HttpClient();
    }
}
