using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.ResponseDto.Authentication
{
    public class UserAuthenticationResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = String.Empty;
    }
}
