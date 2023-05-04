using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
   public class UserResponseDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public RoleResponseDto Role { get; set; }

        public string PasswordHash { get; set; }

        

    }
}
