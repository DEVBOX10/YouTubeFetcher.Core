namespace YouTubeFetcher.Core.Commands
{
    public interface IConverterCommand
    {
        string Convert(string input, int index = 0);
    }
}
