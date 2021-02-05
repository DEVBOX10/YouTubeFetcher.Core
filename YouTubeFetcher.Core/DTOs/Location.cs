namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// Location holds the url information for the actual stream
    /// </summary>
    internal sealed record Location
    {
        /// <summary>
        /// The type of signature which is applied for encrypting the origin url
        /// </summary>
        public string SignatureType { get; init; }

        /// <summary>
        /// The actual signature which was applied to encrypt the url
        /// </summary>
        public string Signature { get; init; }

        /// <summary>
        /// The encrypted url
        /// </summary>
        public string Url { get; init; }
    }
}
