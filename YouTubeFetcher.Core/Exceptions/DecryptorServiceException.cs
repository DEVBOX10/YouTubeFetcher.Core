namespace YouTubeFetcher.Core.Exceptions
{
    /// <summary>
    /// The exception for the DecryptorService
    /// </summary>
    public class DecryptorServiceException : YouTubeFetcherCoreException
    {
        /// <inheritdoc/>
        public DecryptorServiceException(string message) : base(message) { }
    }
}
