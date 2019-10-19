namespace FaraMedia.Services.Security {
	using System;
	using System.IO;
	using System.Security.Cryptography;
	using System.Text;
	using System.Web.Security;

	using FaraMedia.Core.Domain.Configuration;
	using FaraMedia.Services.Utilities;

	public sealed class EncryptionService : IEncryptionService {
		private readonly SecuritySettings _securitySettings;

		public EncryptionService(SecuritySettings securitySettings) {
			_securitySettings = securitySettings;
		}

		public string CreateSaltKey(int size) {
			var rng = new RNGCryptoServiceProvider();
			var buffer = new byte[size];
			rng.GetBytes(buffer);

			var saltKey = Convert.ToBase64String(buffer);

			return saltKey;
		}

		public string CreatePasswordHash(string password,
		                                 string saltkey,
		                                 HashedPasswordAlgorithm hashAlgorithm) {
			var saltAndPassword = string.Concat(password,
			                                    saltkey);
			var hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPassword,
			                                                                            hashAlgorithm.ToString());

			return hashedPassword;
		}

		public string EncryptText(string plainText,
		                          string encryptionPrivateKey = "") {
			if (string.IsNullOrEmpty(plainText))
				return plainText;

			if (string.IsNullOrEmpty(encryptionPrivateKey))
				encryptionPrivateKey = _securitySettings.EncryptionKey;

			var desCrypto = new TripleDESCryptoServiceProvider {
					Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0,
					                                                                  16)),
					IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8,
					                                                                 8))
			};

			var encryptedBinary = EncryptTextToMemory(plainText,
			                                          desCrypto.Key,
			                                          desCrypto.IV);

			var base64String = Convert.ToBase64String(encryptedBinary);

			return base64String;
		}

		public string DecryptText(string cipherText,
		                          string encryptionPrivateKey = "") {
			if (string.IsNullOrEmpty(cipherText))
				return cipherText;

			if (string.IsNullOrEmpty(encryptionPrivateKey))
				encryptionPrivateKey = _securitySettings.EncryptionKey;

			var desCrypto = new TripleDESCryptoServiceProvider {
					Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0,
					                                                                  16)),
					IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8,
					                                                                 8))
			};

			var buffer = Convert.FromBase64String(cipherText);

			var memoryDecryptedText = DecryptTextFromMemory(buffer,
			                                                desCrypto.Key,
			                                                desCrypto.IV);

			return memoryDecryptedText;
		}

		private static byte[] EncryptTextToMemory(string data,
		                                          byte[] key,
		                                          byte[] iv) {
			using (var memoryStream = new MemoryStream()) {
				using (var cryptoStream = new CryptoStream(memoryStream,
				                                           new TripleDESCryptoServiceProvider().CreateEncryptor(key,
				                                                                                                iv),
				                                           CryptoStreamMode.Write)) {
					var toEncrypt = new UnicodeEncoding().GetBytes(data);
					cryptoStream.Write(toEncrypt,
					                   0,
					                   toEncrypt.Length);
					cryptoStream.FlushFinalBlock();
				}

				var byteArray = memoryStream.ToArray();

				return byteArray;
			}
		}

		private static string DecryptTextFromMemory(byte[] data,
		                                            byte[] key,
		                                            byte[] iv) {
			using (var memoryStream = new MemoryStream(data)) {
				using (var cryptoStream = new CryptoStream(memoryStream,
				                                           new TripleDESCryptoServiceProvider().CreateDecryptor(key,
				                                                                                                iv),
				                                           CryptoStreamMode.Read)) {
					var streamReader = new StreamReader(cryptoStream,
					                                    new UnicodeEncoding());
					var decryptedText = streamReader.ReadLine();

					return decryptedText;
				}
			}
		}
	}
}