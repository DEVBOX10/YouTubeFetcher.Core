using YouTubeFetcher.Core.Factories;
using YouTubeFetcher.Core.Factories.Interfaces;

namespace YouTubeFetcher.Tests.Services
{
    public class YouTubeServiceTests
    {
        private readonly IYouTubeServiceFactory decryptorService = new YouTubeServiceFactory();
    }
}
