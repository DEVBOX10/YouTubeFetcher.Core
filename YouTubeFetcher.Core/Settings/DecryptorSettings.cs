namespace YouTubeFetcher.Core.Settings
{
    public class DecryptorSettings
    {
        public string DecryptionFunctionRegex { get; set; } = "\\bc\\s*&&\\s*a\\.set\\([^,]+,\\s*(?:encodeURIComponent\\s*\\()?\\s*([\\w$]+)\\(";
        public string FunctionRegex { get; set; } = "\\w+\\.(\\w+)\\(";
        public string DeciphererFunctionNameRegex { get; set; } = "(\\w+)=function\\(\\w+\\){(\\w+)=\\2\\.split\\(\\x22{2}\\);.*?return\\s+\\2\\.join\\(\\x22{2}\\)}";
        public string DeciphererFunctionBodyRegex { get; set; } = "(?!h\\.){0}=function\\(\\w+\\)\\{{(.*?)\\}}";
        public string DeciphererDefinitionNameRegex { get; set; } = "(\\w+).\\w+\\(\\w+,\\d+\\);";
        public string DeciphererDefinitionBodyRegex { get; set; } = "var\\s+{0}=\\{{(\\w+:function\\(\\w+(,\\w+)?\\)\\{{(.*?)\\}}),?\\}};";
        public string ParametersRegex { get; set; } = "\\(\\w+,(\\d+)\\)";
        public string SliceFunctionRegex { get; set; } = "(\\\"\")?{0}(\"\")?:\\bfunction\\b\\([a],b\\).(\\breturn\\b)?.?\\w+\\.";
        public string SwapFunctionRegex { get; set; } = "(\\\"\")?{0}(\\\"\")?:\\bfunction\\b\\(\\w+\\,\\w\\).\\bvar\\b.\\bc=a\\b";
        public string ReverseFunctionRegex { get; set; } = "(\\\"\")?{0}(\\\"\")?:\\bfunction\\b\\(\\w+\\){{\\w+\\.reverse";
        public string SignatureTypeKey { get; set; } = "sp";
        public string DefaultSignatureType { get; set; } = "signature";
        public string SignatureKey { get; set; } = "s";
        public string UrlIndicator { get; set; } = "url";
        public string FallbackHostKey { get; set; } = "fallback_host";
        public string RateBypassKey { get; set; } = "ratebypass";
        public string DefaultRateBypass { get; set; } = "yes";
    }
}
