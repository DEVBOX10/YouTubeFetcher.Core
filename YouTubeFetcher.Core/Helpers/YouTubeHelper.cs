using System;
using System.Web;
using YouTubeFetcher.Core.DTOs;

namespace YouTubeFetcher.Core.Helpers
{
    static class YouTubeHelper
    {
        internal static Location GetLocationBySignatureCipher(string signatureCipher)
        {
            var query = HttpUtility.ParseQueryString(signatureCipher);
            var location = new Location
            {
                SignatureKey = query.Get("sp") ?? "signature",
                Signature = query.Get("s"),
                Url = Uri.UnescapeDataString(query.Get(nameof(Location.Url).ToLower())),
            };

            var fallbackHostKey = "fallback_host";
            var fallbackHost = query.Get(fallbackHostKey);
            if (!string.IsNullOrEmpty(fallbackHost))
                location.Url += $"&{fallbackHostKey}={fallbackHost}";

            if (!location.Url.Contains("ratebypass"))
                location.Url += "&ratebypass=yes";

            return location;
        }

        internal static int GetAudioBitRate(int itag)
        {
            switch (itag)
            {
                case 5:
                case 6:
                case 250:
                    return 64;
                case 17:
                    return 24;
                case 18:
                case 82:
                case 83:
                    return 96;
                case 22:
                case 37:
                case 38:
                case 45:
                case 46:
                case 101:
                case 102:
                case 172:
                    return 192;
                case 34:
                case 35:
                case 43:
                case 44:
                case 100:
                case 140:
                case 171:
                    return 128;
                case 36:
                    return 38;
                case 84:
                case 85:
                    return 152;
                case 251:
                    return 160;
                case 139:
                case 249:
                    return 48;
                case 141:
                    return 256;
                default:
                    return -1;
            }
        }
    }
}
