using Xunit;
using YouTubeFetcher.Core.Extensions;

namespace YouTubeFetcher.Core.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("https://www.youtube.com/watch?v=dQw4w9WgXcQ", "dQw4w9WgXcQ")]
        [InlineData("https://youtu.be/dQw4w9WgXcQ", "dQw4w9WgXcQ")]
        [InlineData("https://youtube.com/embed/dQw4w9WgXcQ", "dQw4w9WgXcQ")]
        [InlineData("dQw4w9WgXcQ", "dQw4w9WgXcQ")]
        public void ExtractYouTubeVideoIdTest(string input, string expected)
        {
            Assert.Equal(expected, input.ExtractYouTubeVideoId());
        }
    }
}
