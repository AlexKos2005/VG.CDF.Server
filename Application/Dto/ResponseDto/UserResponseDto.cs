﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.ResponseDto
{
   public class UserResponseDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public RoleResponseDto Role { get; set; }

        public string PasswordHash { get; set; }

        

    }
}