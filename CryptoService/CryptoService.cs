using System;
using System.Security.Cryptography;

namespace CryptoService
{
    public static class CryptoService
    {
        private const int SaltByteSize = 256;
        private const int HashByteSize = 256;
        private const int IterationCount = 26531;

        public static byte[] ComputeHash(string password, byte[] salt, int iterations = 26531, int hashByteSize = 256)
        {
            using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt))
            {
                rfc2898DeriveBytes.IterationCount = iterations;
                return rfc2898DeriveBytes.GetBytes(hashByteSize);
            }
        }

        public static byte[] GenerateSalt(int saltByteSize = 256)
        {
            using (RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[saltByteSize];
                cryptoServiceProvider.GetBytes(data);
                return data;
            }
        }

        public static bool IsValidPassword(string password, string storedSalt, string passHash)
        {
            byte[] salt = Convert.FromBase64String(storedSalt);
            byte[] hash = CryptoService.ComputeHash(password, salt, 26531, 256);
            byte[] numArray = Convert.FromBase64String(passHash);
            if (numArray.Length != hash.Length)
                return false;
            for (int index = 0; index < hash.Length; ++index)
            {
                if ((int)hash[index] != (int)numArray[index])
                    return false;
            }
            return true;
        }
    }

}
