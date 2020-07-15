using System.Net.Http;

namespace YouTubeFetcher.Core.Factories.Interfaces
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient();
    }
}
