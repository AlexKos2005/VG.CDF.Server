using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace VG.CDF.Server.Application.Extentions
{
   public static class HashServiceExtention
    {
        public static string GetHashCodeSHA256(this string hashingValue)
        {
            var hash = SHA256.Create();
            try
            {
                var tr = Encoding.UTF8.GetBytes(hashingValue);
                var result = BitConverter.ToString(hash.ComputeHash(tr)).Replace("-", "");

                return result;
            }
            finally
            {
                hash.Clear();
            }
        }

    }
}
