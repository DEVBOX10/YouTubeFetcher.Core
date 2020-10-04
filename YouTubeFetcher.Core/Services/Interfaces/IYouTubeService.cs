using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using YouTubeFetcher.Core.DTOs;

namespace YouTubeFetcher.Core.Services.Interfaces
{
    /// <summary>
    /// The service for the youtube requests
    /// </summary>
    public interface IYouTubeService
    {
        /// <summary>
        /// Returns all information about a specific video
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <returns></returns>
        Task<VideoInformation?> GetInformationAsync(string id);

        /// <summary>
        /// Returns video details
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <returns></returns>
        Task<VideoDetail?> GetVideoDetailsAsync(string id);

        /// <summary>
        /// Returns streaming data from a video
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <returns></returns>
        Task<StreamingData?> GetStreamingDataAsync(string id);

        /// <summary>
        /// Returns a specific format from a video
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="itag">The itag of the format</param>
        /// <returns></returns>
        Task<Format?> GetFormatByITagAsync(string id, int itag);

        /// <summary>
        /// Returns a stream for a format
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="itag">The itag of the format</param>
        /// <returns></returns>
        Task<Stream> GetStreamAsync(string id, int itag);

        /// <summary>
        /// Returns a stream for a location
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="format">A format object</param>
        /// <returns></returns>
        Task<Stream> GetStreamAsync(string id, Format format);

        /// <summary>
        /// Returns the decrypted url for a format
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="itag">The itag of the format</param>
        /// <returns></returns>
        Task<string> GetStreamUrlAsync(string id, int itag);

        /// <summary>
        /// Returns the decrypted url for a location
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="format">A format object</param>
        /// <returns></returns>
        Task<string> GetStreamUrlAsync(string id, Format format);

        /// <summary>
        /// Returns all items in a playlist
        /// </summary>
        /// <param name="playlistId">The id of the playlist</param>
        /// <returns></returns>
        Task<IEnumerable<PlaylistItem>> GetItemsFromPlaylistAsync(string playlistId);

        /// <summary>
        /// Looking up YouTube videos, which are returned for the specific searchTerm
        /// </summary>
        /// <param name="searchTerm">The searchTerm for YouTube</param>
        /// <returns></returns>
        Task<SearchResult> SearchAsync(string searchTerm);
    }
}
