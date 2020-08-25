namespace YouTubeFetcher.Core.Commands
{
    /// <summary>
    /// The converter for slicing a input
    /// </summary>
    public class SliceConverterCommand : IConverterCommand
    {
        /// <summary>
        /// Slices the input at the given index
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="index">The index for slicing</param>
        /// <returns></returns>
        public string Convert(string input, int index) => input.Substring(index);
    }
}
