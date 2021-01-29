namespace YouTubeFetcher.Core.Settings
{
    /// <summary>
    /// The settings for the DecryptorService are declared in this class
    /// </summary>
    public class DecryptorSettings
    {
        /// <summary>
        /// Regex for reading the function out of the player js file
        /// </summary>
        public string FunctionRegex { get; init; } = "\\w+\\.(\\w+)\\(";

        /// <summary>
        /// Regex for reading the deciphered function name
        /// </summary>
        public string DecipheredFunctionNameRegex { get; init; } = "(\\w+)=function\\(\\w+\\){(\\w+)=\\2\\.split\\(\\x22{2}\\);.*?return\\s+\\2\\.join\\(\\x22{2}\\)}";

        /// <summary>
        /// Regex for reading the deciphered function body
        /// </summary>
        public string DecipheredFunctionBodyRegex { get; init; } = "(?!h\\.){0}=function\\(\\w+\\)\\{{(.*?)\\}}";

        /// <summary>
        /// Regex for reading the deciphered definition name
        /// </summary>
        public string DecipheredDefinitionNameRegex { get; init; } = "([\\$_\\w]+).\\w+\\(\\w+,\\d+\\);";

        /// <summary>
        /// Regex for reading the deciphered definition body
        /// </summary>
        public string DecipheredDefinitionBodyRegex { get; init; } = "var\\s+{0}=\\{{(\\w+:function\\(\\w+(,\\w+)?\\)\\{{(.*?)\\}}),?\\}};";

        /// <summary>
        /// Regex for reading the parameters
        /// </summary>
        public string ParametersRegex { get; init; } = "\\(\\w+,(\\d+)\\)";

        /// <summary>
        /// Regex for reading the slice function
        /// </summary>
        public string SliceFunctionRegex { get; init; } = "(\\\"\")?{0}(\"\")?:\\bfunction\\b\\([a],b\\).(\\breturn\\b)?.?\\w+\\.";

        /// <summary>
        /// Regex for reading the swap function
        /// </summary>
        public string SwapFunctionRegex { get; init; } = "(\\\"\")?{0}(\\\"\")?:\\bfunction\\b\\(\\w+\\,\\w\\).\\bvar\\b.\\bc=a\\b";

        /// <summary>
        /// Regex for reading the reverse function
        /// </summary>
        public string ReverseFunctionRegex { get; init; } = "(\\\"\")?{0}(\\\"\")?:\\bfunction\\b\\(\\w+\\){{\\w+\\.reverse";

        /// <summary>
        /// The key which indicates the signature type
        /// </summary>
        public string SignatureTypeKey { get; init; } = "sp";

        /// <summary>
        /// The default signature type
        /// </summary>
        public string DefaultSignatureType { get; init; } = "signature";

        /// <summary>
        /// The key which indicates the signature
        /// </summary>
        public string SignatureKey { get; init; } = "s";

        /// <summary>
        /// The key which indicates the url
        /// </summary>
        public string UrlKey { get; init; } = "url";

        /// <summary>
        /// The key which indicates the fallback host
        /// </summary>
        public string FallbackHostKey { get; init; } = "fallback_host";

        /// <summary>
        /// The key which indicates the rate bypass
        /// </summary>
        public string RateBypassKey { get; init; } = "ratebypass";

        /// <summary>
        /// The default rate bypass
        /// </summary>
        public string DefaultRateBypass { get; init; } = "yes";
    }
}
