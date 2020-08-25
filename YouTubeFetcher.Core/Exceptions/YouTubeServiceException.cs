namespace YouTubeFetcher.Core.Exceptions
{
    /// <summary>
    /// The exception for the YouTubeService
    /// </summary>
    public class YouTubeServiceException : YouTubeFetcherCoreException
    {
        /// <summary>
        /// Constructor for initializing the exception
        /// </summary>
        /// <param name="message"></param>
        public YouTubeServiceException(string message) : base(message) { }
    }
}
