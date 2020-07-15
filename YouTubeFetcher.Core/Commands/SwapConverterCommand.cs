namespace YouTubeFetcher.Core.Commands
{
    public class SwapConverterCommand : IConverterCommand
    {
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
