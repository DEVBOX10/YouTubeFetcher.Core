namespace YouTubeFetcher.Core.DTOs
{
    public struct Format
    {
        public int ITag { get; set; }

        public string MimeType { get; set; }

        public int Bitrate { get; set; }

        public int Height { get; set; }

        public int ContentLength { get; set; }

        public string Quality { get; set; }

        public string Url { get; set; }

        public string SignatureCipher { get; set; }

        // YouTube only sets a signaturecipher if the stream is encrypted
        public bool IsEncrypted => !string.IsNullOrEmpty(SignatureCipher);
    }
}
