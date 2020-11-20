namespace YouTubeFetcher.Core.DTOs
{
    internal struct Location
    {
        public string SignatureType { get; init; }

        public string Signature { get; set; }

        public string Url { get; set; }
    }
}
