namespace YouTubeFetcher.Core.Commands
{
    public class SliceConverterCommand : IConverterCommand
    {
        public string Convert(string input, int index) => input.Substring(index);
    }
}
