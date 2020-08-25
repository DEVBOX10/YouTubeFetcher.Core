using System;

namespace YouTubeFetcher.Core.Settings
{
    /// <summary>
    /// The settings for the YouTubeService are declared in this class
    /// </summary>
    public class YouTubeSettings
    {
        /// <summary>
        /// The base YouTube path
        /// </summary>
        public string BasePath { get; set; } = "https://www.youtube.com/";

        /// <summary>
        /// The vinfo api endpoint for getting video related informations
        /// </summary>
        public string InfoRelativeUri { get; set; } = "get_video_info?video_id={0}&el=detailpage";

        /// <summary>
        /// The embed video path
        /// </summary>
        public string EmbedRelativeUri { get; set; } = "embed/{0}";

        /// <summary>
        /// The playlist api endpoint for getting items in a playlist
        /// </summary>
        public string PlaylistRelativeUri { get; set; } = "list_ajax?style=json&action_get_list=1&list={0}";

        /// <summary>
        /// The key which indicates if the videoinfo returned a error
        /// </summary>
        public string ErrorCodeKey { get; set; } = "errorcode";

        /// <summary>
        /// The key which is neeeded for getting the tag which includes the player in the site
        /// </summary>
        public string JsPlayerKey { get; set; } = "name=\"player_ias/base\"";

        /// <summary>
        /// The key for getting the player response in the video info return value
        /// </summary>
        public string PlayerResponseKey { get; set; } = "player_response";

        /// <summary>
        /// The key which is needed for getting the items for a playlist from the playlist api response 
        /// </summary>
        public string PlaylistItemsKey { get; set; } = "video";

        /// <summary>
        /// The length of a playlist id
        /// </summary>
        public int PlaylistIdLength { get; set; } = 34;

        /// <summary>
        /// The BasePath as Uri
        /// </summary>
        public Uri BaseUri => new Uri(BasePath);

        /// <summary>
        /// The Uri for the video information endpoint
        /// </summary>
        public Uri InfoUri => new Uri(BaseUri, InfoRelativeUri);

        /// <summary>
        /// The Uri for the embed url
        /// </summary>
        public Uri EmbedUri => new Uri(BaseUri, EmbedRelativeUri);

        /// <summary>
        /// The Uri for the playlist api endpoint
        /// </summary>
        public Uri PlaylistUri => new Uri(BaseUri, PlaylistRelativeUri);
    }
}
