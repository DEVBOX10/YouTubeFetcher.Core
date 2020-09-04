namespace YouTubeFetcher.Core.Exceptions
{
    /// <summary>
    /// The exception for the YouTubeService
    /// </summary>
    public class YouTubeServiceException : YouTubeFetcherCoreException
    {
        /// <inheritdoc/>
        public YouTubeServiceException(string message) : base(message) { }
    }
}
