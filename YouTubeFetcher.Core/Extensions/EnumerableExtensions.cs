using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace YouTubeFetcher.Core.Extensions
{
    internal static class EnumerableExtensions
    {
        internal static IEnumerable<T> GetChildrenByKey<T>(this IEnumerable<JToken> tokens, string key) where T : new()
        {
            return tokens
                .Select(x => x.SelectToken(key))
                .Where(x => x != null)
                .Select(x => x.ToObject<T>());
        }
    }
}
