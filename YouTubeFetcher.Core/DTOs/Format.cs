using YouTubeFetcher.Core.Helpers;

namespace YouTubeFetcher.Core.DTOs
{
    public struct Format
    {
        public int ITag { get; set; }

        public string MimeType { private get; set; }

        public int Bitrate { private get; set; }

        public int Height { private get; set; }

        public int ContentLength { private get; set; }

        public string Quality { private get; set; }

        public string Url
        {
            private get => string.Empty;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    Location = new Location { Url = value };
            }
        }

        public string SignatureCipher
        {
            private get => string.Empty;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    Location = YouTubeHelper.GetLocationBySignatureCipher(value);
            }
        }

        public Specification Specification => new Specification
        {
            MimeType = MimeType,
            Resolution = Height,
            Bitrate = Height == 0 ? YouTubeHelper.GetAudioBitRate(ITag) : Bitrate,
            ContentLength = ContentLength,
            Quality = Quality
        };

        public Location Location { get; set; }
    }
}
