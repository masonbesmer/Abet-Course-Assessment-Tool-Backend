using System.Security.Cryptography; // AES, CryptoStream, Rfc2898DeriveBytes
using System.Text.Json; // JSON Serializer
using System.Text; // UTF8 Encoding
using System.IO; // MemoryStream, StreamReader

namespace AbetApi.Security {


    public class AES
    {


        // this class represents the JSON data so that it can be deserialized from a string into an object
        private class AESConfiguration
        {
            public string Salt { get; set; }
            public int Iterations { get; set; }
            public int KeyLength { get; set; }
            public int InitializationVectorLength { get; set; }
        }


        private static void GenerateKeyAndIV(
            string password, 
            byte[] salt, 
            int iterations, 
            int keySize, 
            int initializationVectorLength, 
            out byte[] key, 
            out byte[] initializationVector) {

            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations)) {
                const int byteSize = 8;
                key = deriveBytes.GetBytes(keySize / byteSize);
                initializationVector = deriveBytes.GetBytes(initializationVectorLength / byteSize);
            }
        }


        private static string DecryptPassword(byte[] encryptedPassword, byte[] salt, int iterations, int keyLength, int initializationVectorLength) {

            byte[] key, initializationVector;
            GenerateKeyAndIV("secret_password", salt, iterations, keyLength, initializationVectorLength, out key, out initializationVector);

            using (var aes = Aes.Create()) {

                aes.Key = key;
                aes.IV = initializationVector;

                using (var memoryStream = new MemoryStream(encryptedPassword))
                using (var decryptor = aes.CreateDecryptor())
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)) {

                    using (var streamReader = new StreamReader(cryptoStream)) {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }


        private static byte[] EncryptPassword(string plaintextPassword, byte[] salt, int iterations, int keyLength, int initializationVectorLength)
        {

            byte[] key, initializationVector;
            GenerateKeyAndIV(plaintextPassword, salt, iterations, keyLength, initializationVectorLength, out key, out initializationVector);

            using (var aes = Aes.Create())
            {

                aes.Key = key;
                aes.IV = initializationVector;

                using (var memoryStream = new MemoryStream())
                using (var encryptor = aes.CreateEncryptor())
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {

                    byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintextPassword);

                    cryptoStream.Write(plaintextBytes, 0, plaintextBytes.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }


        // parses the JSON data into an object that can be accessed
        private static AESConfiguration getConfiguration (string configurationFile) {
            string aesConfigData = File.ReadAllText(configurationFile);
            AESConfiguration aesConfig = JsonSerializer.Deserialize<AESConfiguration>(aesConfigData);
            return aesConfig;
        }


        // returns the decrypted password as a string
        public static string Decrypt(byte[] encryptedPassword) {
            AESConfiguration aesConfig = getConfiguration("./aesConfig.json"); // parses the JSON data into an object that can be accessed
            return DecryptPassword(encryptedPassword, Encoding.UTF8.GetBytes(aesConfig.Salt), aesConfig.Iterations, aesConfig.KeyLength, aesConfig.InitializationVectorLength); // calls the AES decryption algorithm with configuration
        }


        // returns the encrypted password as a bytearray
        public static byte[] Encrypt(string plaintextPassword)
        {
            AESConfiguration aesConfig = getConfiguration("aesConfig.json"); // parses the JSON data into an object that can be accessed
            return EncryptPassword(plaintextPassword, Encoding.UTF8.GetBytes(aesConfig.Salt), aesConfig.Iterations, aesConfig.KeyLength, aesConfig.InitializationVectorLength); // calls the AES encryption algorithm with configuration
        }


    }
}
