using VG.CDF.Server.Application.Interfaces.Configurations;

namespace VG.CDF.Server.Infrastructure.Configurations
{
   public class DbConnectionConfig : IDbConnectionConfig
    {
        public string ConnectionString { get; set; }
    }
}
