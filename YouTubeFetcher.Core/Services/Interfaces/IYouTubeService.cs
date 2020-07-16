using System.IO;
using System.Threading.Tasks;
using YouTubeFetcher.Core.DTOs;

namespace YouTubeFetcher.Core.Services.Interfaces
{
    public interface IYouTubeService
    {
        /// <summary>
        /// Returns all informations about a specific video
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
        /// Returns a streamable url for a format
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="itag">The itag of the format</param>
        /// <returns></returns>
        Task<string> GetStreamUrlAsync(string id, int itag);

        /// <summary>
        /// Returns a streamable url for a location
        /// </summary>
        /// <param name="id">The id of the video</param>
        /// <param name="format">A format object</param>
        /// <returns></returns>
        Task<string> GetStreamUrlAsync(string id, Format format);
    }
}
