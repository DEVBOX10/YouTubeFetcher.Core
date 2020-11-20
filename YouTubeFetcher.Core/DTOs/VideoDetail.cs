namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// This struct represents the video details which are given from the api endpoint
    /// </summary>
    public readonly struct VideoDetail
    {
        /// <summary>
        /// The id of the video
        /// </summary>
        public string VideoId { get; init; }

        /// <summary>
        /// The title of the video
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// The duration in seconds
        /// </summary>
        public long LengthSeconds { get; init; }

        /// <summary>
        /// The average user rating
        /// </summary>
        public double AverageRating { get; init; }

        /// <summary>
        /// The view count of the video
        /// </summary>
        public long ViewCount { get; init; }

        /// <summary>
        /// The id of the channel which uploaded the video
        /// </summary>
        public string ChannelId { get; init; }
    }
}