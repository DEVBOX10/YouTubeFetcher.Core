namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// This class represents the video renderer
    /// </summary>
    public sealed record VideoRenderer : BaseRenderer
    {
        /// <summary>
        /// The id for the video
        /// </summary>
        public string VideoId { get; init; }
    }
}
