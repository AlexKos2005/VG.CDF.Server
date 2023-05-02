using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto.Authentication
{
    public class UserAuthenticationRequestDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
