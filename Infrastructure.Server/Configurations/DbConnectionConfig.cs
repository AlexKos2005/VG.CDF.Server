using BreadCommunityWeb.Blz.Infrastructure.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Configurations
{
   public class DbConnectionConfig : IDbConnectionConfig
    {
        public string ConnectionString { get; set; }
    }
}
