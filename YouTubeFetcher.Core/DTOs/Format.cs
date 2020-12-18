// ReSharper disable All
namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// This struct represents the format which is returned from the api endpoint
    /// </summary>
    public struct Format
    {
        /// <summary>
        /// The itag is like a id for a format
        /// </summary>
        public int ITag { get; set; }

        /// <summary>
        /// The mime type of the format
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// The bitrate of the format
        /// </summary>
        public int Bitrate { get; set; }

        /// <summary>
        /// The height of a format (if 0 its a audio format)
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The content length of a format
        /// </summary>
        public int ContentLength { get; set; }

        /// <summary>
        /// The quality of a format
        /// </summary>
        public string Quality { get; set; }

        /// <summary>
        /// The url of a format (only set when not encrypted)
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The signature cipher of a format (only set when encrypted)
        /// </summary>
        public string SignatureCipher { get; set; }

        /// <summary>
        /// YouTube only sets a signature cipher if the format is encrypted
        /// </summary>
        public bool IsEncrypted => !string.IsNullOrEmpty(SignatureCipher);
    }
}
