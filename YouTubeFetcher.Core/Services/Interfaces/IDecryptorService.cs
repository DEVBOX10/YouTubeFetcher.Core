namespace YouTubeFetcher.Core.Services.Interfaces
{
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
