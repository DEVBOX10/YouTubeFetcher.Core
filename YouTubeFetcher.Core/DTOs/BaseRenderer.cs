using Newtonsoft.Json;
using System.Collections.Generic;

namespace YouTubeFetcher.Core.DTOs
{
    /// <summary>
    /// The class which is used for storing the base data of the renderers
    /// </summary>
    public abstract class BaseRenderer
    {
        /// <summary>
        /// All attributes that don't have a property will be put into this dictionary
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> ExtraAttributes { get; init; }
    }
}
