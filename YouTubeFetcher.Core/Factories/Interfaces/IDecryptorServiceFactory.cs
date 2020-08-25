using YouTubeFetcher.Core.Services.Interfaces;

namespace YouTubeFetcher.Core.Factories.Interfaces
{
    /// <summary>
    /// Interfaces for the DecryptorServiceFactory
    /// </summary>
    public interface IDecryptorServiceFactory
    {
        /// <summary>
        /// This method creates the DecryptorService
        /// </summary>
        /// <returns></returns>
        IDecryptorService Create();
    }
}
