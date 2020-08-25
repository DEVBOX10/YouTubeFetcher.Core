namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// This struct represents the video details which are given from the api endpoint
    /// </summary>
    public struct VideoDetail
    {
        /// <summary>
        /// The id of the video
        /// </summary>
        public string VideoId { get; set; }

        /// <summary>
        /// The title of the video
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The duration in seconds
        /// </summary>
        public long LengthSeconds { get; set; }

        /// <summary>
        /// The average user rating
        /// </summary>
        public double AverageRating { get; set; }

        /// <summary>
        /// The view count of the video
        /// </summary>
        public long ViewCount { get; set; }

        /// <summary>
        /// The id of the cannel which uploaded the video
        /// </summary>
        public string ChannelId { get; set; }
    }
}