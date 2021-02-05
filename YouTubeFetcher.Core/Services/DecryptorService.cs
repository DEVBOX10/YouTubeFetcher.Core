using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using YouTubeFetcher.Core.DTOs;
using YouTubeFetcher.Core.Exceptions;
using YouTubeFetcher.Core.Services.Interfaces;
using YouTubeFetcher.Core.Settings;

namespace YouTubeFetcher.Core.Services
{
    /// <inheritdoc/>
    public class DecryptorService : IDecryptorService
    {
        private delegate string ConvertFunction(string input, int index);

        private readonly DecryptorSettings _settings;
        private readonly IDictionary<string, ConvertFunction> _convertMap;

        /// <summary>
        /// Constructor for DecryptorService
        /// </summary>
        /// <param name="options"></param>
        public DecryptorService(IOptions<DecryptorSettings> options)
        {
            _settings = options.Value;
            _convertMap = new Dictionary<string, ConvertFunction> {
                { _settings.ReverseFunctionRegex, (input, _) =>  ReverseFunction(input)},
                { _settings.SliceFunctionRegex, SliceFunction },
                { _settings.SwapFunctionRegex, SwapFunction },
            };
        }

        /// <inheritdoc/>
        public string DecryptSignatureCipher(string js, string signatureCipher)
        {
            TryGetFirstMatch(js, _settings.DecipheredFunctionNameRegex, out var decipheredFunctionName);
            TryGetFirstMatch(js, string.Format(_settings.DecipheredFunctionBodyRegex, Regex.Escape(decipheredFunctionName)), out var decipheredFunctionBody, RegexOptions.Singleline);

            if (!TryGetFirstMatch(decipheredFunctionBody, _settings.DecipheredDefinitionNameRegex, out var decipheredDefinitionName))
                throw new DecryptorServiceException("Couldn't find signature deciphered definition name.");

            if (!TryGetFirstMatch(js, string.Format(_settings.DecipheredDefinitionBodyRegex, Regex.Escape(decipheredDefinitionName)), out var decipheredDefinitionBody, RegexOptions.Singleline))
                throw new DecryptorServiceException("Couldn't find signature deciphered definition body.");

            var location = GetLocationFromSignatureCipher(signatureCipher);
            var resolvedSignature = ExecuteFunction(decipheredFunctionBody, decipheredDefinitionBody, location.Signature);
            return location.Url + $"&{location.SignatureType}={resolvedSignature}";
        }

        private string ExecuteFunction(string decipheredFunctionBody, string decipheredDefinitionBody, string signature)
        {
            return decipheredFunctionBody.Split(";")
                .Aggregate(signature, (current, functionLine) => ExecuteLine(functionLine, decipheredDefinitionBody, current));
        }

        private string ExecuteLine(string functionLine, string decipheredDefinitionBody, string signature)
        {
            if (!TryGetFirstMatch(functionLine, _settings.FunctionRegex, out var function)
                    || !TryGetConverter(decipheredDefinitionBody, function, out var command))
                return signature;

            TryGetFirstMatch(functionLine, _settings.ParametersRegex, out var indexVal);
            int.TryParse(indexVal, NumberStyles.AllowThousands, NumberFormatInfo.InvariantInfo, out var index);
            return command.Invoke(signature, index);
        }

        private bool TryGetConverter(string decipheredDefinitionBody, string function, out ConvertFunction command)
        {
            var escapedFunction = Regex.Escape(function);
            command = null;
            foreach (var (key, value) in _convertMap)
            {
                if (!TryGetFirstMatch(decipheredDefinitionBody, string.Format(key, escapedFunction), out _))
                    continue;
                command = value;
                break;
            }
            return command != null;
        }

        private Location GetLocationFromSignatureCipher(string signatureCipher)
        {
            var query = HttpUtility.ParseQueryString(signatureCipher);

            var url = Uri.UnescapeDataString(query.Get(_settings.UrlKey) ?? string.Empty);
            var fallbackHost = query.Get(_settings.FallbackHostKey);
            if (!string.IsNullOrEmpty(fallbackHost))
                url += $"&{_settings.FallbackHostKey}={fallbackHost}";
            if (!url.Contains(_settings.RateBypassKey))
                url += $"&{_settings.RateBypassKey}={_settings.DefaultRateBypass}";

            return new Location
            {
                SignatureType = query.Get(_settings.SignatureTypeKey) ?? _settings.DefaultSignatureType,
                Signature = query.Get(_settings.SignatureKey),
                Url = url
            };
        }

        private static string ReverseFunction(string input) => string.Concat(input.Reverse());

        private static string SliceFunction(string input, int index) => input.Substring(index);

        private static string SwapFunction(string input, int index)
        {
            var inputArray = input.ToCharArray();
            index %= input.Length; // Takes 0 if index >= length of input. That prevents a System.IndexOutOfRangeException
            inputArray[0] = input[index];
            inputArray[index] = input[0];
            return string.Concat(inputArray);
        }

        private static bool TryGetFirstMatch(string input, string pattern, out string value, RegexOptions regexOptions = RegexOptions.None)
        {
            value = string.Empty;
            var match = Regex.Match(input, pattern, regexOptions);
            if (!match.Success)
                return false;
            value = match.Groups[1].Value;
            return true;
        }
    }
}
