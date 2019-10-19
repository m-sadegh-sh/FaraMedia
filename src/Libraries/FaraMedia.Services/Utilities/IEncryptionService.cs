namespace FaraMedia.Services.Utilities {
    using FaraMedia.Core.Domain.Configuration;

    public interface IEncryptionService {
        string CreateSaltKey(int size);
        string CreatePasswordHash(string password, string saltkey, HashedPasswordAlgorithm hashAlgorithm);
        string EncryptText(string plainText, string encryptionPrivateKey = "");
        string DecryptText(string cipherText, string encryptionPrivateKey = "");
    }
}