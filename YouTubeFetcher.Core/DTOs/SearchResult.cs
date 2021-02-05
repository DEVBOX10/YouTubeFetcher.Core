using System.Collections.Generic;

namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// This struct represents the search result
    /// </summary>
    public sealed record SearchResult
    {
        /// <summary>
        /// This property contains all video results
        /// </summary>
        public IEnumerable<VideoRenderer> VideoRenderers { get; init; }

        /// <summary>
        /// This property contains all playlist results
        /// </summary>
        public IEnumerable<RadioRenderer> RadioRenderers { get; init; }
    }
}
