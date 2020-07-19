using Xunit;
using YouTubeFetcher.Core.Factories;
using YouTubeFetcher.Core.Factories.Interfaces;

namespace YouTubeFetcher.Tests.Factories
{
    public class HttpClientFactoryTests
    {
        private readonly IHttpClientFactory _clientFactory = new HttpClientFactory();

        [Fact]
        public void CreateClientTest()
        {
            using var client = _clientFactory.CreateClient();
            Assert.NotNull(client);
        }
    }
}
