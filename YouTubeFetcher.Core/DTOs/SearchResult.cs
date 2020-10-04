using System.Collections.Generic;

namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// This struct represents the search result
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// This property contains all video results
        /// </summary>
        public IEnumerable<VideoRenderer> VideoRenderers { get; set; }

        /// <summary>
        /// This property contains all playlist results
        /// </summary>
        public IEnumerable<RadioRenderer> RadioRenderers { get; set; }
    }
}
