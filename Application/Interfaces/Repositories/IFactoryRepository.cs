
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
   public interface IFactoryRepository : ICrud<Project,int>
    {
        Task<List<Project>> GetAllFactories();
        Task Save(List<Project> factories);

        Task<Project?> GetFactoryByExternalId(int factoryExternalId);
        Task<List<Project>> GetAllFactories(int userId);
    }
}
