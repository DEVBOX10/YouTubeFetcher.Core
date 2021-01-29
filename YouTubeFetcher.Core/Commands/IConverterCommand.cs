namespace YouTubeFetcher.Core.Commands
{
    /// <summary>
    /// This interfaces is needed for the different signature transformation
    /// </summary>
    public interface IConverterCommand
    {
        /// <summary>
        /// This method converts the given input with the converters logic
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="index">If needed a index for making operations with</param>
        /// <returns></returns>
        string Convert(string input, int index = 0);
    }
}
