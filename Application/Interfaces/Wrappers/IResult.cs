using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Interfaces.Wrappers
{
    public interface IResult
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}
