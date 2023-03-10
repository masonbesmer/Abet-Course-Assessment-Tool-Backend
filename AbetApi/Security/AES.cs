using System.Security.Cryptography; // AES, CryptoStream, Rfc2898DeriveBytes
using System.Text; // UTF8 Encoding
using System.IO; // MemoryStream, StreamReader

namespace AbetApi.Security {


    public class AES
    {

        private readonly byte[] _key;
        private readonly byte[] _iv;

        // this class represents the JSON data so that it can be deserialized from a string into an object
        private class AESConfiguration
        {
            public byte[] Salt { get; set; }
            public int Iterations { get; set; }
            public int KeyLength { get; set; }
            public int InitializationVectorLength { get; set; }
            public AESConfiguration(byte[] s, int i, int lk, int liv)
            {
                Salt = s;
                Iterations = i;
                KeyLength = lk;
                InitializationVectorLength = liv;
            }
        }


        public AES(string password)
        {
            byte[] SALT = Encoding.ASCII.GetBytes(System.Environment.GetEnvironmentVariable("AES_SALT"));
            int ITERATIONS = System.Convert.ToInt32(System.Environment.GetEnvironmentVariable("AES_ITERATIONS"));
            int KEY_LENGTH = System.Convert.ToInt32(System.Environment.GetEnvironmentVariable("AES_LEN_KEY"));
            int INITIALIZATION_VECTOR_LENGTH = System.Convert.ToInt32(System.Environment.GetEnvironmentVariable("AES_LEN_INIT_VEC"));
            GenerateKeyAndIV(password, SALT, ITERATIONS, KEY_LENGTH, INITIALIZATION_VECTOR_LENGTH, out _key, out _iv);
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


        public byte[] Encrypt(string plaintext)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;

            var textBytes = Encoding.UTF8.GetBytes(plaintext); // get the bytes of the plaintext in UTF-8 format
            using var cipher = aes.CreateEncryptor(aes.Key, aes.IV);
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, cipher, CryptoStreamMode.Write);
            cryptoStream.Write(textBytes, 0, textBytes.Length);
            cryptoStream.FlushFinalBlock();

            return memoryStream.ToArray();
        }


        public string Decrypt(byte[] encryptedBytes)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;

            using var cipher = aes.CreateDecryptor(aes.Key, aes.IV); // create a cipher using the key and initialization vector
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, cipher, CryptoStreamMode.Write);
            cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            cryptoStream.FlushFinalBlock();

            var decryptedBytes = memoryStream.ToArray();
            return Encoding.UTF8.GetString(decryptedBytes, 0, decryptedBytes.Length);
        }


    }
}
