using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Extentions
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
