namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// The video information which are given from the api endpoint
    /// </summary>
    public struct VideoInformation
    {
        /// <summary>
        /// The video details of the video
        /// </summary>
        public VideoDetail VideoDetails { get; set; }

        /// <summary>
        /// The streaming data of the video
        /// </summary>
        public StreamingData StreamingData { get; set; }
    }
}
