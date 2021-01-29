using Microsoft.Extensions.Options;
using YouTubeFetcher.Core.Factories.Interfaces;
using YouTubeFetcher.Core.Services;
using YouTubeFetcher.Core.Services.Interfaces;
using YouTubeFetcher.Core.Settings;

namespace YouTubeFetcher.Core.Factories
{
    /// <inheritdoc/>
    public class DecryptorServiceFactory : IDecryptorServiceFactory
    {
        /// <inheritdoc/>
        public IDecryptorService Create()
        {
            return new DecryptorService(Options.Create(new DecryptorSettings()));
        }
    }
}
