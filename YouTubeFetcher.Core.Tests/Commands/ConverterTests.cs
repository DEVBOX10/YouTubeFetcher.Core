using Xunit;
using YouTubeFetcher.Core.Commands;

namespace YouTubeFetcher.Core.Tests.Commands
{
    public class ConverterTests
    {
        private readonly IConverterCommand _reverse = new ReverseConverterCommand();
        private readonly IConverterCommand _slice = new SliceConverterCommand();
        private readonly IConverterCommand _swap = new SwapConverterCommand();

        [Theory]
        [InlineData("ABC", "CBA")]
        [InlineData("what/ever", "reve/tahw")]
        [InlineData("asdfghjkl", "lkjhgfdsa")]
        public void ReverseTest(string input, string expected)
        {
            Assert.Equal(expected, _reverse.Convert(input));
        }

        [Theory]
        [InlineData("abcd,efg", "efg", 5)]
        [InlineData("HelloThere", "HelloThere", 0)]
        [InlineData("OneMore", "More", 3)]
        public void SliceTest(string input, string expected, int index)
        {
            Assert.Equal(expected, _slice.Convert(input, index));
        }

        [Theory]
        [InlineData("aBcDeF-gHiJKlMnOp", "FBcDea-gHiJKlMnOp", 5)]
        [InlineData("aBcDeF-gHiJKlMnOp", "DBcaeF-gHiJKlMnOp", 3)]
        [InlineData("aBcDeF-gHiJKlMnOp", "-BcDeFagHiJKlMnOp", 6)]
        [InlineData("hallo", "oallh", 4)]
        [InlineData("swapHereAndSkip", "ewapHersAndSkip", 7)]
        public void SwapTest(string input, string expected, int index)
        {
            Assert.Equal(expected, _swap.Convert(input, index));
        }
    }
}
