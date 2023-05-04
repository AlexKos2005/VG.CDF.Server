
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
   public interface IFactoryRepository : ICrud<Factory,int>
    {
        Task<List<Factory>> GetAllFactories();
        Task Save(List<Factory> factories);

        Task<Factory?> GetFactoryByExternalId(int factoryExternalId);
        Task<List<Factory>> GetAllFactories(int userId);
    }
}
