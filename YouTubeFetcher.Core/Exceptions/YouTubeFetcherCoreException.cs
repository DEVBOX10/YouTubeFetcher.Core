using System;

namespace YouTubeFetcher.Core.Exceptions
{
    /// <summary>
    /// The base class for all excpetions thrown from this class library
    /// </summary>
    public abstract class YouTubeFetcherCoreException : Exception
    {
        /// <summary>
        /// Constructor for initializing the exception
        /// </summary>
        /// <param name="message"></param>
        public YouTubeFetcherCoreException(string message) : base(message) { }
    }
}
