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
        public string BasePath { get; init; } = "https://www.youtube.com/";

        /// <summary>
        /// The video api endpoint for getting video related information
        /// </summary>
        public string InfoRelativeUri { get; init; } = "get_video_info?video_id={0}&el=detailpage";

        /// <summary>
        /// The embed video path
        /// </summary>
        public string EmbedRelativeUri { get; init; } = "embed/{0}";

        /// <summary>
        /// The playlist api endpoint for getting items in a playlist
        /// </summary>
        public string PlaylistRelativeUri { get; init; } = "list_ajax?style=json&action_get_list=1&list={0}";

        /// <summary>
        /// The relative uri for searching on YouTube
        /// </summary>
        public string SearchRelativeUri { get; init; } = "results?search_query={0}";

        /// <summary>
        /// The key which indicates if the video info returned a error
        /// </summary>
        public string ErrorCodeKey { get; init; } = "errorcode";

        /// <summary>
        /// The key which is needed for getting the tag which includes the player in the site
        /// </summary>
        public string JsPlayerKey { get; init; } = "name=\"player_ias/base\"";

        /// <summary>
        /// The key for getting the player response in the video info return value
        /// </summary>
        public string PlayerResponseKey { get; init; } = "player_response";

        /// <summary>
        /// The key which is needed for getting the items for a playlist from the playlist api response 
        /// </summary>
        public string PlaylistItemsKey { get; init; } = "video";

        /// <summary>
        /// The length of a playlist id
        /// </summary>
        public int PlaylistIdLength { get; init; } = 34;

        /// <summary>
        /// The key for identifying the initial data for YouTube
        /// </summary>
        public string InitialDataKey { get; init; } = "ytInitialData";

        /// <summary>
        /// The path for describing the search results in the JSON file
        /// </summary>
        public string VideoRendererTokenPath { get; init; } = "contents.twoColumnSearchResultsRenderer.primaryContents.sectionListRenderer.contents[0].itemSectionRenderer.contents";

        /// <summary>
        /// The key for indication whether a value is a video renderer
        /// </summary>
        public string VideoRenderKey { get; init; } = "videoRenderer";

        /// <summary>
        /// The key for indication whether a value is a radio renderer
        /// </summary>
        public string RadioRenderersKey { get; init; } = "radioRenderer";

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

        /// <summary>
        /// The Uri for searching on YouTube
        /// </summary>
        public Uri SearchUri => new Uri(BaseUri, SearchRelativeUri);
    }
}
