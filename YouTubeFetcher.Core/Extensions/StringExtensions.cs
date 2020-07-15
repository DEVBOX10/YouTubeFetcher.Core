namespace YouTubeFetcher.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ExtractYouTubeVideoId(this string videoLink)
        {
            videoLink = videoLink.Replace("youtu.be/", "youtube.com/watch?v=")
                    .Replace("youtube.com/embed/", "youtube.com/watch?v=")
                    .Replace("/v/", "/watch?v=")
                    .Replace("/watch#", "/watch?");

            var vIndex = videoLink.IndexOf("v=");
            if (vIndex > -1)
                videoLink = videoLink.Substring(vIndex + 2);

            var andIndex = videoLink.IndexOf("&");
            if (andIndex > -1)
                videoLink = videoLink.Substring(0, andIndex);

            return videoLink;
        }
    }
}
