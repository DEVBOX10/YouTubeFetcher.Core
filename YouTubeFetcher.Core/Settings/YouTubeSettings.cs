using System;

namespace YouTubeFetcher.Core.Settings
{
    public class YouTubeSettings
    {
        public string BasePath { get; set; } = "https://www.youtube.com/";
        public string VideoInfoRelativePath { get; set; } = "get_video_info?video_id={0}&el=detailpage";
        public string VideoRelativePath { get; set; } = "embed/{0}";
        public string ErrorCodeKey { get; set; } = "errorcode";
        public string JsPlayerKey { get; set; } = "name=\"player_ias/base\"";
        public string PlayerResponseKey { get; set; } = "player_response";

        public Uri BaseUri => new Uri(BasePath);
        public Uri VideoInfoUri => new Uri(BaseUri, VideoInfoRelativePath);
        public Uri VideoUri => new Uri(BaseUri, VideoRelativePath);
    }
}
