﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Interfaces
{
    public interface IDbConnectionConfig
    {
        string ConnectionString { get; set; }
    }
}
