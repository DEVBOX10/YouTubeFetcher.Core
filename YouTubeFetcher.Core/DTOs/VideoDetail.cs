namespace YouTubeFetcher.Core.DTOs
{
    public struct VideoDetail
    {
        public string VideoId { get; set; }

        public string Title { get; set; }

        public long LengthSeconds { get; set; }

        public double AverageRating { get; set; }

        public long ViewCount { get; set; }

        public string ChannelId { get; set; }
    }
}