using Microsoft.Extensions.Options;
using YouTubeFetcher.Core.Factories.Interfaces;
using YouTubeFetcher.Core.Services;
using YouTubeFetcher.Core.Settings;

namespace YouTubeFetcher.Core.Factories
{
    public class DecryptorServiceFactory : IDecryptorServiceFactory
    {
        public DecryptorService Create()
        {
            return new DecryptorService(Options.Create(new DecryptorSettings()));
        }
    }
}
