using YouTubeFetcher.Core.DTOs;

namespace YouTubeFetcher.Core.Services.Interfaces
{
    public interface IDecryptorService
    {
        /// <summary>
        /// Decrypts a location and returns it
        /// </summary>
        /// <param name="js">The js content of the player</param>
        /// <param name="location">The location object to decrypt</param>
        /// <returns></returns>
        Location DecryptLocation(string js, Location location);
    }
}
