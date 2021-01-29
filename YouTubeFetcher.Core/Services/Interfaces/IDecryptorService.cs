namespace YouTubeFetcher.Core.Services.Interfaces
{
    /// <summary>
    /// The service for the decryption logic
    /// </summary>
    public interface IDecryptorService
    {
        /// <summary>
        /// Decrypts a signatureCipher value and returns it
        /// </summary>
        /// <param name="js">The js content of the player</param>
        /// <param name="signatureCipher">The signatureCipher to decrypt</param>
        /// <returns></returns>
        string DecryptSignatureCipher(string js, string signatureCipher);
    }
}
