using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Services
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
