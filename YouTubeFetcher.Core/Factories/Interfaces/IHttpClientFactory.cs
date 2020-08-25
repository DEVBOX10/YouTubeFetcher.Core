using System.Net.Http;

namespace YouTubeFetcher.Core.Factories.Interfaces
{
    /// <summary>
    /// Interfaces for the HttpClientFactory
    /// </summary>
    public interface IHttpClientFactory
    {
        /// <summary>
        /// This method creates the HttpClient
        /// </summary>
        /// <returns></returns>
        HttpClient CreateClient();
    }
}
