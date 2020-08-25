using YouTubeFetcher.Core.Factories.Interfaces;
using YouTubeFetcher.Core.Services;
using YouTubeFetcher.Core.Services.Interfaces;
using YouTubeFetcher.Core.Settings;

namespace YouTubeFetcher.Core.Factories
{
    /// <summary>
    /// The factory for creating a YouTubrService
    /// </summary>
    public class YouTubeServiceFactory : IYouTubeServiceFactory
    {
        /// <summary>
        /// This method creates a YouTubeService
        /// </summary>
        /// <returns></returns>
        public IYouTubeService Create()
        {
            return new YouTubeService(new HttpClientFactory(), new DecryptorServiceFactory().Create(), new YouTubeSettings());
        }
    }
}
