namespace YouTubeFetcher.Core.Commands
{
    /// <summary>
    /// The converter for swapping a input
    /// </summary>
    public class SwapConverterCommand : IConverterCommand
    {
        /// <summary>
        /// Swaps the letters at position 0 and the position of the index
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="index">The index for swapping</param>
        /// <returns></returns>
        public string Convert(string input, int index)
        {
            var inputArray = input.ToCharArray();
            index %= input.Length; // Takes 0 if index >= length of input. That prevents a System.IndexOutOfRangeException
            inputArray[0] = input[index];
            inputArray[index] = input[0];
            return string.Concat(inputArray);
        }
    }
}
