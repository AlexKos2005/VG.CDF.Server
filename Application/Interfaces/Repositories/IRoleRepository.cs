using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
  public interface IRoleRepository : ICrud<Role,int>
    {
        Task<List<Role>?> GetAllRoles();
    }
}
