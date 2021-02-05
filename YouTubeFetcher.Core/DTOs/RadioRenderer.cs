namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// This class represents the radio renderer
    /// </summary>
    public sealed record RadioRenderer : BaseRenderer
    {
        /// <summary>
        /// The id for the playlist
        /// </summary>
        public string PlaylistId { get; init; }
    }
}
