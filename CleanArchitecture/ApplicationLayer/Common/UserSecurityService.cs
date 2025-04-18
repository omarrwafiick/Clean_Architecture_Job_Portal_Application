using System.Security.Cryptography;

namespace ApplicationLayer.Common
{
    public static class UserSecurityService
    {
        public static string HashPassword(string password) => HashPasswordSec(password);

        public static bool VerifyPassword(string hashedPassword, string inputPassword) => VerifyPasswordSec(hashedPassword, inputPassword);

        private static string HashPasswordSec(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[16];
            rng.GetBytes(salt);
             
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);  
             
            byte[] hashBytes = new byte[48];  
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);
             
            return Convert.ToBase64String(hashBytes);
        }

        private static bool VerifyPasswordSec(string hashedPassword, string inputPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
             
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
             
            var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);
             
            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }
    }
}
