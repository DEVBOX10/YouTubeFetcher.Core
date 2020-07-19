using System.Text.RegularExpressions;

namespace YouTubeFetcher.Core.Extensions
{
    public static class StringExtensions
    {
        private const string VIDEO_ID_REGEX = "((?<=(v|V)/)|(?<=be/)|(?<=(\\?|\\&)v=)|(?<=embed/))([\\w-]+)";

        public static string ExtractYouTubeVideoId(this string videoLink)
        {
            var match = new Regex(VIDEO_ID_REGEX).Match(videoLink);
            if (match.Success)
                return match.Value;

            return videoLink;
        }
    }
}
