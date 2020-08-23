using System;

namespace YouTubeFetcher.Core.Settings
{
    public class YouTubeSettings
    {
        public string BasePath { get; set; } = "https://www.youtube.com/";
        public string InfoRelativeUri { get; set; } = "get_video_info?video_id={0}&el=detailpage";
        public string EmbedRelativeUri { get; set; } = "embed/{0}";
        public string PlaylistRelativeUri { get; set; } = "list_ajax?style=json&action_get_list=1&list={0}";
        public string ErrorCodeKey { get; set; } = "errorcode";
        public string JsPlayerKey { get; set; } = "name=\"player_ias/base\"";
        public string PlayerResponseKey { get; set; } = "player_response";
        public string PlayListItemsKey { get; set; } = "video";

        public Uri BaseUri => new Uri(BasePath);
        public Uri InfoUri => new Uri(BaseUri, InfoRelativeUri);
        public Uri EmbedUri => new Uri(BaseUri, EmbedRelativeUri);
        public Uri PlaylistUri => new Uri(BaseUri, PlaylistRelativeUri);
    }
}
