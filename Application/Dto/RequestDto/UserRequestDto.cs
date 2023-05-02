﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
   public class UserRequestDto
    {
      
        public int Id { get; private set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public RoleRequestDto Role { get; set; }

        public List<int> FactoryExternalIds { get; set; }
    }
}
