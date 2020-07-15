using Microsoft.Extensions.Options;
using YouTubeFetcher.Core.Factories.Interfaces;
using YouTubeFetcher.Core.Services;
using YouTubeFetcher.Core.Settings;

namespace YouTubeFetcher.Core.Factories
{
    public class YouTubeServiceFactory : IYouTubeServiceFactory
    {
        public YouTubeService Create()
        {
            return new YouTubeService(new HttpClientFactory(), new DecryptorService(Options.Create(new DecryptorSettings())), Options.Create(new YouTubeSettings()));
        }
    }
}
