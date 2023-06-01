using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
   public interface IFactoryActionsInfoRepository : ICrud<ProjectActionsInfo,int>
    {
        Task<ProjectActionsInfo?> GetByFactoryExternalId(int factoryExternalId);
    }
}
