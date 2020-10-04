using Newtonsoft.Json;

namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// This class represents the video renderer
    /// </summary>
    public class VideoRenderer : BaseRenderer
    {
        /// <summary>
        /// The id for the video
        /// </summary>
        public string VideoId { get; set; }

        /// <summary>
        /// The title of the video
        /// </summary>
        [JsonProperty("title.runs[0].text")]
        public string Title { get; set; }
    }
}
