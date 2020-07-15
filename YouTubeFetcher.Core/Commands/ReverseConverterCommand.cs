using System.Linq;

namespace YouTubeFetcher.Core.Commands
{
    public class ReverseConverterCommand : IConverterCommand
    {
        public string Convert(string input, int index = 0) => string.Concat(input.Reverse());
    }
}
