﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
   public interface IJwtService<T>
    {
        public string BuildToken(T entity);
    }
}
