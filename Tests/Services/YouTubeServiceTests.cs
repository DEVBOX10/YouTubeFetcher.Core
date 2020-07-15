using System.Threading.Tasks;
using Xunit;
using YouTubeFetcher.Core.Factories;
using YouTubeFetcher.Core.Services.Interfaces;

namespace YouTubeFetcher.Tests.Services
{
    public class YouTubeServiceTests
    {
        private readonly IYouTubeService youTubeService = new YouTubeServiceFactory().Create();

        [Theory]
        [InlineData("dQw4w9WgXcQ", true)]
        [InlineData("https://www.youtube.com/watch?v=dQw4w9WgXcQ", false)]
        [InlineData("asdfsdaWgXcasdfas", false)]
        public async Task GetInformationTestAsync(string id, bool expected)
        {
            var information = await youTubeService.GetInformationAsync(id);
            Assert.Equal(information.HasValue, expected);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", true)]
        [InlineData("https://www.youtube.com/watch?v=dQw4w9WgXcQ", false)]
        [InlineData("asdfsdaWgXcasdfas", false)]
        public async Task GetDetailsTestAsync(string id, bool expected)
        {
            var details = await youTubeService.GetVideoDetailsAsync(id);
            Assert.Equal(details.HasValue, expected);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", true)]
        [InlineData("https://www.youtube.com/watch?v=dQw4w9WgXcQ", false)]
        [InlineData("asdfsdaWgXcasdfas", false)]
        public async Task GetStreamingDataTestAsync(string id, bool expected)
        {
            var streamingData = await youTubeService.GetStreamingDataAsync(id);
            Assert.Equal(streamingData.HasValue, expected);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", 18, true)]
        [InlineData("dQw4w9WgXcQ", 134, true)]
        [InlineData("asdfsdaWgXcasdfas", 0, false)]
        public async Task GetFormatByITagTestAsync(string id, int itag, bool expected)
        {
            var format = await youTubeService.GetFormatByITagAsync(id, itag);
            Assert.Equal(format.HasValue, expected);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", 18, true)]
        [InlineData("dQw4w9WgXcQ", 134, true)]
        [InlineData("asdfsdaWgXcasdfas", 0, false)]
        public async Task GetStreamTestAsync(string id, int itag, bool expected)
        {
            var stream = await youTubeService.GetStreamAsync(id, itag);
            Assert.Equal(stream != null, expected);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", 18, true)]
        [InlineData("dQw4w9WgXcQ", 134, true)]
        [InlineData("asdfsdaWgXcasdfas", 0, false)]
        public async Task GetStreamByLocationTestAsync(string id, int itag, bool expected)
        {
            var format = await youTubeService.GetFormatByITagAsync(id, itag);
            var stream = await youTubeService.GetStreamAsync(id, format?.Location ?? default);
            Assert.Equal(stream != null, expected);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", 18, true)]
        [InlineData("dQw4w9WgXcQ", 134, true)]
        [InlineData("asdfsdaWgXcasdfas", 0, false)]
        public async Task GetStreamUrlTestAsync(string id, int itag, bool expected)
        {
            var url = await youTubeService.GetStreamUrlAsync(id, itag);
            Assert.Equal(string.IsNullOrEmpty(url), !expected);
        }

        [Theory]
        [InlineData("dQw4w9WgXcQ", 18, true)]
        [InlineData("dQw4w9WgXcQ", 134, true)]
        [InlineData("asdfsdaWgXcasdfas", 0, false)]
        public async Task GetStreamUrlByLocationTestAsync(string id, int itag, bool expected)
        {
            var format = await youTubeService.GetFormatByITagAsync(id, itag);
            var stream = await youTubeService.GetStreamUrlAsync(id, format?.Location ?? default);
            Assert.Equal(stream != null, expected);
        }
    }
}
