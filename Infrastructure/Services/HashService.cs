using System;
using System.Text;
using System.Security.Cryptography;
using VG.CDF.Server.Application.Interfaces.Services;

namespace VG.CDF.Server.Infrastructure.Services
{
    public class HashService : IHashService
    {
        public string? GetHashCodeSHA256(string hashingValue)
        {
            var hash = SHA256.Create();
            try
            {
                var tr = Encoding.UTF8.GetBytes(hashingValue);
                var result = BitConverter.ToString(hash.ComputeHash(tr)).Replace("-", "");

                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                hash.Clear();
            }
        }
    }
}
