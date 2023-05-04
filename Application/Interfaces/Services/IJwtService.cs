using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Interfaces.Services
{
   public interface IJwtService<T>
    {
        public string BuildToken(T entity);
    }
}
