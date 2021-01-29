using System.Net.Http;
using Xunit;
using YouTubeFetcher.Core.Factories;

namespace YouTubeFetcher.Core.Tests.Factories
{
    public class HttpClientFactoryTests
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpClientFactoryTests()
        {
            _clientFactory = new HttpClientFactory();
        }

        [Fact]
        public void CreateClientTest()
        {
            var client = _clientFactory.CreateClient();
            Assert.NotNull(client);
        }
    }
}
