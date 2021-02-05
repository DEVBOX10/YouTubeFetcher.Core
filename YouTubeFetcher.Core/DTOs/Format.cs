// ReSharper disable All
namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// This struct represents the format which is returned from the api endpoint
    /// </summary>
    public sealed record Format
    {
        /// <summary>
        /// The itag is like a id for a format
        /// </summary>
        public int ITag { get; init; }

        /// <summary>
        /// The mime type of the format
        /// </summary>
        public string MimeType { get; init; }

        /// <summary>
        /// The bitrate of the format
        /// </summary>
        public int Bitrate { get; init; }

        /// <summary>
        /// The height of a format (if 0 its a audio format)
        /// </summary>
        public int Height { get; init; }

        /// <summary>
        /// The content length of a format
        /// </summary>
        public int ContentLength { get; init; }

        /// <summary>
        /// The quality of a format
        /// </summary>
        public string Quality { get; init; }

        /// <summary>
        /// The url of a format (only set when not encrypted)
        /// </summary>
        public string Url { get; init; }

        /// <summary>
        /// The signature cipher of a format (only set when encrypted)
        /// </summary>
        public string SignatureCipher { get; init; }

        /// <summary>
        /// YouTube only sets a signature cipher if the format is encrypted
        /// </summary>
        public bool IsEncrypted => !string.IsNullOrEmpty(SignatureCipher);
    }
}
