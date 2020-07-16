using YouTubeFetcher.Core.Factories;
using YouTubeFetcher.Core.Services.Interfaces;

namespace YouTubeFetcher.Tests.Services
{
    public class DecryptorServiceTests
    {
        private readonly IDecryptorService decryptorService = new DecryptorServiceFactory().Create();
    }
}
