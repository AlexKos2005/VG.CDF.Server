using System;
using System.Text;
using System.Security.Cryptography;

namespace VG.CDF.Server.Infrastructure.Extentions
{
    public static class HashSHA256Converter
    {
        public static string GetHashCodeSHA256(this string password)
        {
            var hash = SHA256.Create();

            var bytes = Encoding.UTF8.GetBytes(password);
            var hashCode256 = BitConverter.ToString(hash.ComputeHash(bytes)).Replace("-", "");

            return hashCode256;
        }
    }
}
