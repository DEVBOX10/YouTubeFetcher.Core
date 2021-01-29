using Newtonsoft.Json;

namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// This struct represents a item which is returned from the api endpoint
    /// </summary>
    public struct PlaylistItem
    {
        /// <summary>
        /// The video id of a playlist item
        /// </summary>
        [JsonProperty("encrypted_id")]
        public string Id { get; init; }

        /// <summary>
        /// The title of the playlist item
        /// </summary>
        public string Title { get; init; }
    }
}
