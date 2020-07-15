namespace YouTubeFetcher.Core.DTOs
{
    public struct Specification
    {
        public string MimeType { get; set; }

        public int Resolution { get; set; }

        public int Bitrate { get; set; }

        public int ContentLength { get; set; }

        public string Quality { get; set; }
    }
}
