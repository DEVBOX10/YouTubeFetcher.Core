namespace YouTubeFetcher.Core.DTOs
{
    public struct Location
    {
        public string SignatureKey { get; set; }

        public string Signature { get; set; }

        public string Url { get; set; }

        public bool IsEncrypted => !string.IsNullOrEmpty(Signature);
    }
}
