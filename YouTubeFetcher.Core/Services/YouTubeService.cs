using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using YouTubeFetcher.Core.DTOs;
using YouTubeFetcher.Core.Exceptions;
using YouTubeFetcher.Core.Extensions;
using YouTubeFetcher.Core.Services.Interfaces;
using YouTubeFetcher.Core.Settings;

namespace YouTubeFetcher.Core.Services
{
    /// <inheritdoc/>
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
        /// <param name="options"></param>
        public YouTubeService(IHttpClientFactory httpClientFactory, IDecryptorService decryptorService, IOptions<YouTubeSettings> options)
        {
            _httpClientFactory = httpClientFactory;
            _decryptorService = decryptorService;
            _settings = options.Value;
        }

        /// <inheritdoc/>
        public async Task<VideoInformation?> GetInformationAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync(string.Format(_settings.InfoUri.OriginalString, id));
            if (!result.IsSuccessStatusCode)
                throw new YouTubeServiceException($"There was a problem fetching video information for {id}. {result.ReasonPhrase}");

            var content = await result.Content.ReadAsStringAsync();
            if (content.Contains(_settings.ErrorCodeKey))
                return null; // if the error-code is given the video wasn't found by the api endpoint

            var query = HttpUtility.ParseQueryString(content);
            var playerResponse = query.Get(_settings.PlayerResponseKey);
            if (string.IsNullOrEmpty(playerResponse))
                throw new YouTubeServiceException($"Couldn't find player response for {id}");

            return JsonConvert.DeserializeObject<VideoInformation>(playerResponse);
        }

        /// <inheritdoc/>
        public async Task<VideoDetail?> GetVideoDetailsAsync(string id)
        {
            var videoInformation = await GetInformationAsync(id);

            return videoInformation?.VideoDetails;
        }

        /// <inheritdoc/>
        public async Task<StreamingData?> GetStreamingDataAsync(string id)
        {
            var videoInformation = await GetInformationAsync(id);

            return videoInformation?.StreamingData;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public async Task<Stream> GetStreamAsync(string id, int itag)
        {
            var format = await GetFormatByITagAsync(id, itag);
            if (!format.HasValue)
                return null;

            return await GetStreamAsync(id, format.Value);
        }

        /// <inheritdoc/>
        public async Task<Stream> GetStreamAsync(string id, Format format)
        {
            var url = await GetStreamUrlAsync(id, format);
            if (string.IsNullOrEmpty(url))
                return null;

            var client = _httpClientFactory.CreateClient();
            return await client.GetStreamAsync(url);
        }

        /// <inheritdoc/>
        public async Task<string> GetStreamUrlAsync(string id, int itag)
        {
            var format = await GetFormatByITagAsync(id, itag);
            if (!format.HasValue)
                return string.Empty;

            return await GetStreamUrlAsync(id, format.Value);
        }

        /// <inheritdoc/>
        public async Task<string> GetStreamUrlAsync(string id, Format format)
        {
            if (!format.IsEncrypted)
                return format.Url ?? string.Empty;

            var jsPlayer = await GetJsPlayerAsync(id);
            return _decryptorService.DecryptSignatureCipher(jsPlayer, format.SignatureCipher);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PlaylistItem>> GetItemsFromPlaylistAsync(string playlistId)
        {
            if (string.IsNullOrEmpty(playlistId))
                return Enumerable.Empty<PlaylistItem>();

            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync(string.Format(_settings.PlaylistUri.OriginalString, playlistId));
            if (!result.IsSuccessStatusCode)
                return Enumerable.Empty<PlaylistItem>();
            if (playlistId.Length < _settings.PlaylistIdLength)
                throw new YouTubeServiceException($"The playlist {playlistId} is most likely a YouTube Mix. YouTube Mixes aren't supported.");

            var videoContent = await result.Content.ReadAsStringAsync();
            var contentJson = JsonConvert.DeserializeObject<JObject>(videoContent);
            contentJson.TryGetValue(_settings.PlaylistItemsKey, out var value);
            if (value == null)
                throw new YouTubeServiceException($"The items for playlist {playlistId} couldn't be fetched");

            return JsonConvert.DeserializeObject<IEnumerable<PlaylistItem>>(value.ToString());
        }

        /// <inheritdoc/>
        public async Task<SearchResult> SearchAsync(string searchTerm)
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync(string.Format(_settings.SearchUri.OriginalString, searchTerm));
            if (!result.IsSuccessStatusCode)
                throw new YouTubeServiceException($"Something went wrong searching for {searchTerm}");

            var content = await result.Content.ReadAsStringAsync();
            var indexInitial = content.IndexOf(_settings.InitialDataKey, StringComparison.Ordinal);
            if (indexInitial == -1)
                throw new YouTubeServiceException($"The initial data couldn't be located for search-term {searchTerm}");

            var contentFromInitial = content[indexInitial..];
            var equalSymbolIndex = contentFromInitial.IndexOf("=", StringComparison.Ordinal) + 1;
            var endSymbolIndex = contentFromInitial.IndexOf(";", StringComparison.Ordinal);
            if (equalSymbolIndex == 0 || endSymbolIndex == -1)
                throw new YouTubeServiceException("Illegal format for initial data received by YouTube");

            var contentJson = contentFromInitial[equalSymbolIndex..endSymbolIndex];
            var contents = JsonConvert.DeserializeObject<JObject>(contentJson);
            var token = contents.SelectTokens(_settings.VideoRendererTokenPath);
            if (token == null)
                throw new YouTubeServiceException("The search results couldn't be located");

            var renderers = token.Children().ToList();
            var videoRenderers = renderers.GetChildrenByKey<VideoRenderer>(_settings.VideoRenderKey);
            var radioRenderers = renderers.GetChildrenByKey<RadioRenderer>(_settings.RadioRenderersKey);

            return new SearchResult { VideoRenderers = videoRenderers, RadioRenderers = radioRenderers };
        }

        private async Task<string> GetJsPlayerAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
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

            const string srcFindKey = "src=\"";
            var fromSrcValue = contentWithKey.Substring(contentWithKey.IndexOf(srcFindKey, StringComparison.Ordinal) + srcFindKey.Length);
            var resultLink = fromSrcValue.Substring(0, fromSrcValue.IndexOf("\"", StringComparison.Ordinal));

            return resultLink;
        }
    }
}
