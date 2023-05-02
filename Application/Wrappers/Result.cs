using BreadCommunityWeb.Blz.Application.Interfaces.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Wrappers
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
