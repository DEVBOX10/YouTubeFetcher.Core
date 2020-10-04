using Xunit;
using YouTubeFetcher.Core.Factories;
using YouTubeFetcher.Core.Factories.Interfaces;

namespace YouTubeFetcher.Core.Tests.Factories
{
    public class DecryptorServiceFactoryTests
    {
        private readonly IDecryptorServiceFactory _decryptorServiceFactory = new DecryptorServiceFactory();

        [Fact]
        public void CreateTest()
        {
            var service = _decryptorServiceFactory.Create();
            Assert.NotNull(service);
        }
    }
}
