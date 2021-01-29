using System;

namespace YouTubeFetcher.Core.Exceptions
{
    /// <summary>
    /// The base class for all exceptions thrown from this class library
    /// </summary>
    public abstract class YouTubeFetcherCoreException : Exception
    {
        /// <summary>
        /// Constructor for initializing the exception
        /// </summary>
        /// <param name="message"></param>
        protected YouTubeFetcherCoreException(string message) : base(message) { }
    }
}
