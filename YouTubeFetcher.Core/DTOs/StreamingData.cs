using System.Collections.Generic;

namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// The streaming data which is returned from the api endpoint
    /// </summary>
    public readonly struct StreamingData
    {
        /// <summary>
        /// Formats are set by the api endpoint for formats which includes video and audio at the same time
        /// </summary>
        public IEnumerable<Format> Formats { get; init; }

        /// <summary>
        /// Adaptive formats are set by the api endpoint for formats which includes either video or audio information
        /// </summary>
        public IEnumerable<Format> AdaptiveFormats { get; init; }
    }
}