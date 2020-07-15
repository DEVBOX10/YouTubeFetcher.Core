using System.Collections.Generic;

namespace YouTubeFetcher.Core.DTOs
{
    public struct StreamingData
    {
        public IEnumerable<Format> Formats { get; set; }

        public IEnumerable<Format> AdaptiveFormats { get; set; }
    }
}