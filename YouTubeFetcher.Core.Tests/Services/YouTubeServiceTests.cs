using System.Linq;
using System.Threading.Tasks;
using Xunit;
using YouTubeFetcher.Core.Exceptions;
using YouTubeFetcher.Core.Factories;
using YouTubeFetcher.Core.Services.Interfaces;

namespace YouTubeFetcher.Core.Tests.Services
{
    public class YouTubeServiceTests
    {
        private readonly IYouTubeService _youTubeService = new YouTubeServiceFactory().Create();

        [Theory]
        [InlineData("dQw4w9WgXcQ", true)]
        [InlineData("9sTQ0QdkN3Q", true)]
        [InlineData("https://www.youtube.com/watch?v=dQw4w9WgXcQ", false)]
        [InlineData("asdfsdaWgXcasdfas", false)]
        public async Task GetInformationTestAsync(string id, bool expected)
        {
            var information = await _youTubeService.GetInformationAsync(id);
            Assert.Equal(expected, information.HasValue);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", true)]
        [InlineData("9sTQ0QdkN3Q", true)]
        [InlineData("https://www.youtube.com/watch?v=dQw4w9WgXcQ", false)]
        [InlineData("asdfsdaWgXcasdfas", false)]
        public async Task GetDetailsTestAsync(string id, bool expected)
        {
            var details = await _youTubeService.GetVideoDetailsAsync(id);
            Assert.Equal(expected, details.HasValue);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", true)]
        [InlineData("9sTQ0QdkN3Q", true)]
        [InlineData("https://www.youtube.com/watch?v=dQw4w9WgXcQ", false)]
        [InlineData("asdfsdaWgXcasdfas", false)]
        public async Task GetStreamingDataTestAsync(string id, bool expected)
        {
            var streamingData = await _youTubeService.GetStreamingDataAsync(id);
            Assert.Equal(expected, streamingData.HasValue);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", 18, true)]
        [InlineData("dQw4w9WgXcQ", 134, true)]
        [InlineData("9sTQ0QdkN3Q", 18, true)]
        [InlineData("asdfsdaWgXcasdfas", 0, false)]
        public async Task GetFormatByITagTestAsync(string id, int itag, bool expected)
        {
            var format = await _youTubeService.GetFormatByITagAsync(id, itag);
            Assert.Equal(expected, format.HasValue);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", 18, true)]
        [InlineData("dQw4w9WgXcQ", 134, true)]
        [InlineData("9sTQ0QdkN3Q", 18, true)]
        [InlineData("asdfsdaWgXcasdfas", 0, false)]
        public async Task GetStreamTestAsync(string id, int itag, bool expected)
        {
            var stream = await _youTubeService.GetStreamAsync(id, itag);
            Assert.Equal(expected, stream != null);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", 18, true)]
        [InlineData("dQw4w9WgXcQ", 134, true)]
        [InlineData("9sTQ0QdkN3Q", 18, true)]
        [InlineData("asdfsdaWgXcasdfas", 0, false)]
        public async Task GetStreamByFormatTestAsync(string id, int itag, bool expected)
        {
            var format = await _youTubeService.GetFormatByITagAsync(id, itag);
            var stream = await _youTubeService.GetStreamAsync(id, format ?? default);
            Assert.Equal(expected, stream != null);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", 18, true)]
        [InlineData("dQw4w9WgXcQ", 134, true)]
        [InlineData("9sTQ0QdkN3Q", 18, true)]
        [InlineData("asdfsdaWgXcasdfas", 0, false)]
        public async Task GetStreamUrlTestAsync(string id, int itag, bool expected)
        {
            var url = await _youTubeService.GetStreamUrlAsync(id, itag);
            Assert.Equal(expected, !string.IsNullOrEmpty(url));
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", 18, true)]
        [InlineData("dQw4w9WgXcQ", 134, true)]
        [InlineData("9sTQ0QdkN3Q", 18, true)]
        [InlineData("asdfsdaWgXcasdfas", 0, false)]
        public async Task GetStreamUrlByFormatTestAsync(string id, int itag, bool expected)
        {
            var format = await _youTubeService.GetFormatByITagAsync(id, itag);
            var url = await _youTubeService.GetStreamUrlAsync(id, format ?? default);
            Assert.Equal(expected, !string.IsNullOrEmpty(url));
        }

        [Theory]
        [InlineData("PLOZ08ThmX07zk-w3C5kb7hWMX7vsfpxz_", true)] // Public playlist
        [InlineData("PLGBuKfnErZlD_VXiQ8dkn6wdEYHbC3u0i", true)] // Public playlist
        [InlineData("RD3ulab09SEnI", false, true)] // YouTube Mix playlist (user specific)
        [InlineData("S9vfFEw3v6XMq2wDFmBPI2eAtWpjoDrAps", false)] // Random not actual playlist
        public async Task GetItemsFromPlaylistTestAsync(string playlistId, bool shouldHaveItems, bool shouldThrowError = false)
        {
            if (shouldThrowError)
                await Assert.ThrowsAsync<YouTubeServiceException>(() => _youTubeService.GetItemsFromPlaylistAsync(playlistId));
            else
            {
                var information = await _youTubeService.GetItemsFromPlaylistAsync(playlistId);
                Assert.Equal(shouldHaveItems, information.Any());
            }
        }

        [Theory]
        [InlineData("Never gonna give you up")]
        [InlineData("Nothing else matters")]
        [InlineData("In the end")]
        [InlineData("Remember the name")]
        public async Task SearchTestAsync(string searchTerm)
        {
            var result = await _youTubeService.SearchAsync(searchTerm);
            Assert.NotNull(result);
        }
    }
}
