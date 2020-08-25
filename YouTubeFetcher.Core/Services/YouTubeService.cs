using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YouTubeFetcher.Core.DTOs;
using YouTubeFetcher.Core.Exceptions;
using YouTubeFetcher.Core.Factories.Interfaces;
using YouTubeFetcher.Core.Services.Interfaces;
using YouTubeFetcher.Core.Settings;

namespace YouTubeFetcher.Core.Services
{
    /// <summary>
    /// The service for the youtube requests
    /// </summary>
    public class YouTubeService : IYouTubeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDecryptorService _decryptorService;
        private readonly YouTubeSettings _settings;

        /// <summary>
        /// The constructor for initializing the service
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="decryptorService"></param>
        /// <param name="settings"></param>
        public YouTubeService(IHttpClientFactory httpClientFactory, IDecryptorService decryptorService, YouTubeSettings settings)
        {
            _httpClientFactory = httpClientFactory;
            _decryptorService = decryptorService;
            _settings = settings;
        }

        /// <summary>
        /// Returns all informations about a specific video
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <returns></returns>
        public async Task<VideoInformation?> GetInformationAsync(string id)
        {
            using var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync(string.Format(_settings.InfoUri.OriginalString, id));
            if (!result.IsSuccessStatusCode)
                throw new YouTubeServiceException($"There was a problem fetching video information for {id}. {result.ReasonPhrase}");

            var content = await result.Content.ReadAsStringAsync();
            if (content.Contains(_settings.ErrorCodeKey))
                return null; // if the errorcode is given the video wasn't found by the api endpoint

            var query = HttpUtility.ParseQueryString(content);
            var playerResponse = query.Get(_settings.PlayerResponseKey);
            if (string.IsNullOrEmpty(playerResponse))
                throw new YouTubeServiceException($"Couldn't find player response for {id}");

            return JsonConvert.DeserializeObject<VideoInformation>(playerResponse);
        }

        /// <summary>
        /// Returns video details
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <returns></returns>
        public async Task<VideoDetail?> GetVideoDetailsAsync(string id)
        {
            var videoInformation = await GetInformationAsync(id);
            if (!videoInformation.HasValue)
                return null;

            return videoInformation.Value.VideoDetails;
        }

        /// <summary>
        /// Returns streaming data from a video
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <returns></returns>
        public async Task<StreamingData?> GetStreamingDataAsync(string id)
        {
            var videoInformation = await GetInformationAsync(id);
            if (!videoInformation.HasValue)
                return null;

            return videoInformation.Value.StreamingData;
        }

        /// <summary>
        /// Returns a specific format from a video
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="itag">The itag of the format</param>
        /// <returns></returns>
        public async Task<Format?> GetFormatByITagAsync(string id, int itag)
        {
            var streamingData = await GetStreamingDataAsync(id);
            if (!streamingData.HasValue)
                return null;

            var streamingDataVal = streamingData.Value;
            var format = streamingDataVal.Formats.Concat(streamingDataVal.AdaptiveFormats).FirstOrDefault(f => f.ITag == itag);
            if (format.ITag == default) // If the itag has its default value (0) then the format wasn't found. A null check isn't possible because a struct can never be null unless ist a nullable struct
                return null;

            return format;
        }

        /// <summary>
        /// Returns a stream for a format
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="itag">The itag of the format</param>
        /// <returns></returns>
        public async Task<Stream> GetStreamAsync(string id, int itag)
        {
            var format = await GetFormatByITagAsync(id, itag);
            if (!format.HasValue)
                return null;

            return await GetStreamAsync(id, format.Value);
        }

        /// <summary>
        /// Returns a stream for a location
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="format">A format object</param>
        /// <returns></returns>
        public async Task<Stream> GetStreamAsync(string id, Format format)
        {
            var url = await GetStreamUrlAsync(id, format);
            if (string.IsNullOrEmpty(url))
                return null;

            using var client = _httpClientFactory.CreateClient();
            return await client.GetStreamAsync(url);
        }

        /// <summary>
        /// Returns a streamable url for a format
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="itag">The itag of the format</param>
        /// <returns></returns>
        public async Task<string> GetStreamUrlAsync(string id, int itag)
        {
            var format = await GetFormatByITagAsync(id, itag);
            if (!format.HasValue)
                return string.Empty;

            return await GetStreamUrlAsync(id, format.Value);
        }

        /// <summary>
        /// Returns a streamable url for a location
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="format">A format object</param>
        /// <returns></returns>
        public async Task<string> GetStreamUrlAsync(string id, Format format)
        {
            if (!format.IsEncrypted)
                return format.Url ?? string.Empty;

            var jsPlayer = await GetJsPlayerAsync(id);
            return _decryptorService.DecryptSignatureCipher(jsPlayer, format.SignatureCipher);
        }

        /// <summary>
        /// Returns all items in a playlist
        /// </summary>
        /// <param name="playlistId">The id of the playlist</param>
        /// <returns></returns>
        public async Task<IEnumerable<PlaylistItem>> GetItemsFromPlaylistAsync(string playlistId)
        {
            if (string.IsNullOrEmpty(playlistId))
                return Enumerable.Empty<PlaylistItem>();

            using var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync(string.Format(_settings.PlaylistUri.OriginalString, playlistId));
            if (!result.IsSuccessStatusCode)
                return Enumerable.Empty<PlaylistItem>();
            else if (playlistId.Length < _settings.PlaylistIdLength)
                throw new YouTubeServiceException($"The playlist {playlistId} is most likely a YouTube Mix. YouTube Mixes aren't supported.");

            var videoContent = await result.Content.ReadAsStringAsync();
            var contentJson = JsonConvert.DeserializeObject<JObject>(videoContent);
            contentJson.TryGetValue(_settings.PlaylistItemsKey, out JToken value);
            if (value == null)
                throw new YouTubeServiceException($"The items for playlist {playlistId} couldn't be fetched");

            return JsonConvert.DeserializeObject<IEnumerable<PlaylistItem>>(value.ToString());
        }

        private async Task<string> GetJsPlayerAsync(string id)
        {
            using var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync(string.Format(_settings.EmbedUri.OriginalString, id));
            if (!result.IsSuccessStatusCode)
                throw new YouTubeServiceException($"The embed site for {id} couldn't be loaded");

            var content = await result.Content.ReadAsStringAsync();
            var jsPlayerUrlRelative = GetJsPlayerUrl(content);
            if (string.IsNullOrWhiteSpace(jsPlayerUrlRelative))
                throw new YouTubeServiceException($"The JsPlayer url wasn't found in the embedded site");

            result = await client.GetAsync(new Uri(_settings.BaseUri, jsPlayerUrlRelative));
            if (!result.IsSuccessStatusCode)
                throw new YouTubeServiceException("Couldn't get the JsPlayer over the given url");

            return await result.Content.ReadAsStringAsync();
        }

        private string GetJsPlayerUrl(string content)
        {
            var contentWithKey = content.Split('<', '>').FirstOrDefault(c => c.Contains(_settings.JsPlayerKey));
            if (string.IsNullOrEmpty(contentWithKey))
                throw new YouTubeServiceException($"The key {_settings.JsPlayerKey} wasn't present in the content");

            var srcFindKey = "src=\"";
            var fromSrcValue = contentWithKey.Substring(contentWithKey.IndexOf(srcFindKey) + srcFindKey.Length);
            var resultLink = fromSrcValue.Substring(0, fromSrcValue.IndexOf("\""));

            return resultLink ?? string.Empty;
        }
    }
}
