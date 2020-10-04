using Newtonsoft.Json;

namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// This class represents the radio renderer
    /// </summary>
    public class RadioRenderer : BaseRenderer
    {
        /// <summary>
        /// The id for the playlist
        /// </summary>
        public string PlaylistId { get; set; }

        /// <summary>
        /// The title of the video
        /// </summary>
        [JsonProperty("title.simpleText")]
        public string Title { get; set; }
    }
}
