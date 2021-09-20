using System;
using System.Security.Cryptography;
using System.Text;

namespace FirstTest.Service.Utility
{
    public static class Hasher
    {
        public static string PasswordHasher(string password)
        {
            using (var sha = SHA256.Create())
            {
                var dataBytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(dataBytes, 0, dataBytes.Length);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}
