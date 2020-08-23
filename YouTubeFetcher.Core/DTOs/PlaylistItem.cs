using Newtonsoft.Json;

namespace YouTubeFetcher.Core.DTOs
{
    public struct PlaylistItem
    {
        [JsonProperty("encrypted_id")]
        public string Id { get; set; }

        public string Title { get; set; }
    }
}
