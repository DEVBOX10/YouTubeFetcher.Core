namespace YouTubeFetcher.Core.Exceptions
{
    /// <summary>
    /// The exception for the DecryptorService
    /// </summary>
    public class DecryptorServiceException : YouTubeFetcherCoreException
    {
        /// <summary>
        /// The consturctor for initializing the exception
        /// </summary>
        /// <param name="message"></param>
        public DecryptorServiceException(string message) : base(message) { }
    }
}
