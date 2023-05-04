using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Interfaces.Wrappers;

namespace VG.CDF.Server.Application.Wrappers
{
    public class Result : IResult
    {
        public List<string> Messages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Succeeded { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class Result<T> : IResult<T>
    {
        public T Data { get; set; }

        public List<string> Messages { get; set; }
        public bool Succeeded { get; set; }
    }
}
