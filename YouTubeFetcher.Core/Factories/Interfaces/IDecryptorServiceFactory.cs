using YouTubeFetcher.Core.Services;

namespace YouTubeFetcher.Core.Factories.Interfaces
{
    public interface IDecryptorServiceFactory
    {
        DecryptorService Create();
    }
}
