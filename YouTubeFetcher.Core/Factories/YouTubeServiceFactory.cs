using YouTubeFetcher.Core.Factories.Interfaces;
using YouTubeFetcher.Core.Services;
using YouTubeFetcher.Core.Services.Interfaces;
using YouTubeFetcher.Core.Settings;

namespace YouTubeFetcher.Core.Factories
{
    /// <inheritdoc/>
    public class YouTubeServiceFactory : IYouTubeServiceFactory
    {
        /// <inheritdoc/>
        public IYouTubeService Create()
        {
            return new YouTubeService(new HttpClientFactory(), new DecryptorServiceFactory().Create(), new YouTubeSettings());
        }
    }
}
