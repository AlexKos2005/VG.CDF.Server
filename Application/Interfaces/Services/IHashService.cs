using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface IHashService
    {
        string? GetHashCodeSHA256(string hashingValue);
    }
}
