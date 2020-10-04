using Xunit;
using YouTubeFetcher.Core.Factories;
using YouTubeFetcher.Core.Factories.Interfaces;

namespace YouTubeFetcher.Core.Tests.Factories
{
    public class YouTubeServiceFactoryTests
    {
        private readonly IYouTubeServiceFactory _youtubeServiceFactory = new YouTubeServiceFactory();

        [Fact]
        public void CreateTest()
        {
            var service = _youtubeServiceFactory.Create();
            Assert.NotNull(service);
        }
    }
}
