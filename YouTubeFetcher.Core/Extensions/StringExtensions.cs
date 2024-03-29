﻿using System.Text.RegularExpressions;

namespace YouTubeFetcher.Core.Extensions
{
    /// <summary>
    /// Extensions for strings which are practical for using with this library
    /// </summary>
    public static class StringExtensions
    {
        private const string VideoIdRegex = "((?<=(v|V)/)|(?<=be/)|(?<=(\\?|\\&)v=)|(?<=embed/))([\\w-]+)";

        /// <summary>
        /// This method extracts the video id from a YouTube link
        /// </summary>
        /// <param name="videoLink"></param>
        /// <returns></returns>
        public static string ExtractYouTubeVideoId(this string videoLink)
        {
            var match = new Regex(VideoIdRegex).Match(videoLink);
            return match.Success ? match.Value : videoLink;
        }
    }
}
