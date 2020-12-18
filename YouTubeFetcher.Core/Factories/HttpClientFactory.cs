using System;
using System.Net.Http;

namespace YouTubeFetcher.Core.Factories
{
    /// <inheritdoc/>
    public class HttpClientFactory : IHttpClientFactory
    {
        private static readonly Lazy<HttpClient> HttpClientLazy = new Lazy<HttpClient>(() => new HttpClient());

        /// <inheritdoc/>
        public HttpClient CreateClient(string name = "") => HttpClientLazy.Value;
    }
}
