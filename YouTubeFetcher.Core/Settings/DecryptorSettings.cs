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
        public string FunctionRegex { get; set; } = "\\w+\\.(\\w+)\\(";

        /// <summary>
        /// Regex for reading the decipherer function name
        /// </summary>
        public string DeciphererFunctionNameRegex { get; set; } = "(\\w+)=function\\(\\w+\\){(\\w+)=\\2\\.split\\(\\x22{2}\\);.*?return\\s+\\2\\.join\\(\\x22{2}\\)}";

        /// <summary>
        /// Regex for reading the decipherer function body
        /// </summary>
        public string DeciphererFunctionBodyRegex { get; set; } = "(?!h\\.){0}=function\\(\\w+\\)\\{{(.*?)\\}}";

        /// <summary>
        /// Regex for reading the decipherer definition name
        /// </summary>
        public string DeciphererDefinitionNameRegex { get; set; } = "([\\$_\\w]+).\\w+\\(\\w+,\\d+\\);";

        /// <summary>
        /// Regex for reading the decipherer definition body
        /// </summary>
        public string DeciphererDefinitionBodyRegex { get; set; } = "var\\s+{0}=\\{{(\\w+:function\\(\\w+(,\\w+)?\\)\\{{(.*?)\\}}),?\\}};";

        /// <summary>
        /// Regex for reading the parameters
        /// </summary>
        public string ParametersRegex { get; set; } = "\\(\\w+,(\\d+)\\)";

        /// <summary>
        /// Regex for reading the slice function
        /// </summary>
        public string SliceFunctionRegex { get; set; } = "(\\\"\")?{0}(\"\")?:\\bfunction\\b\\([a],b\\).(\\breturn\\b)?.?\\w+\\.";

        /// <summary>
        /// Regex for reading the swap function
        /// </summary>
        public string SwapFunctionRegex { get; set; } = "(\\\"\")?{0}(\\\"\")?:\\bfunction\\b\\(\\w+\\,\\w\\).\\bvar\\b.\\bc=a\\b";

        /// <summary>
        /// Regex for reading the reverse function
        /// </summary>
        public string ReverseFunctionRegex { get; set; } = "(\\\"\")?{0}(\\\"\")?:\\bfunction\\b\\(\\w+\\){{\\w+\\.reverse";

        /// <summary>
        /// The key which indicates the signature type
        /// </summary>
        public string SignatureTypeKey { get; set; } = "sp";

        /// <summary>
        /// The default signature type
        /// </summary>
        public string DefaultSignatureType { get; set; } = "signature";

        /// <summary>
        /// The key which indicates the signature
        /// </summary>
        public string SignatureKey { get; set; } = "s";

        /// <summary>
        /// The key which indicates the url
        /// </summary>
        public string UrlKey { get; set; } = "url";

        /// <summary>
        /// The key which indicates the fallback host
        /// </summary>
        public string FallbackHostKey { get; set; } = "fallback_host";

        /// <summary>
        /// The key which indicates the rate bypass
        /// </summary>
        public string RateBypassKey { get; set; } = "ratebypass";

        /// <summary>
        /// The default rate bypass
        /// </summary>
        public string DefaultRateBypass { get; set; } = "yes";
    }
}
