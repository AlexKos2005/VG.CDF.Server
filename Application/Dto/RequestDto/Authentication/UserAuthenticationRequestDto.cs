using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Dto.RequestDto.Authentication
{
    public class UserAuthenticationRequestDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
