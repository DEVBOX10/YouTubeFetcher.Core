using YouTubeFetcher.Core.Factories.Interfaces;
using YouTubeFetcher.Core.Services;
using YouTubeFetcher.Core.Services.Interfaces;
using YouTubeFetcher.Core.Settings;

namespace YouTubeFetcher.Core.Factories
{
    /// <summary>
    /// The factory for creating a DecryptorService
    /// </summary>
    public class DecryptorServiceFactory : IDecryptorServiceFactory
    {
        /// <summary>
        /// This method creates a DecryptorService
        /// </summary>
        /// <returns></returns>
        public IDecryptorService Create()
        {
            return new DecryptorService(new DecryptorSettings());
        }
    }
}
