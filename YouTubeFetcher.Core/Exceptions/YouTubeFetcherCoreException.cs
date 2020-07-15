using System;

namespace YouTubeFetcher.Core.Exceptions
{
    public abstract class YouTubeFetcherCoreException : Exception
    {
        public YouTubeFetcherCoreException(string message) : base(message) { }
    }
}
