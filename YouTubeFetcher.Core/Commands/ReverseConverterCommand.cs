using System.Linq;

namespace YouTubeFetcher.Core.Commands
{
    /// <summary>
    /// The converter for reversing a input
    /// </summary>
    public class ReverseConverterCommand : IConverterCommand
    {
        /// <summary>
        /// This method returns the reversed input
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="index">Index is not needed in this converter</param>
        /// <returns></returns>
        public string Convert(string input, int index = 0) => string.Concat(input.Reverse());
    }
}
