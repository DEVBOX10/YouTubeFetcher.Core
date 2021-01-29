using YouTubeFetcher.Core.Services.Interfaces;

namespace YouTubeFetcher.Core.Factories.Interfaces
{
    /// <summary>
    /// Interfaces for the YouTubeServiceFactory
    /// </summary>
    public interface IYouTubeServiceFactory
    {
        /// <summary>
        /// This method creates the YouTubeService
        /// </summary>
        /// <returns></returns>
        IYouTubeService Create();
    }
}
