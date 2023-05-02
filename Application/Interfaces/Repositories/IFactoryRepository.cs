using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
   public interface IFactoryRepository : ICrud<Factory,int>
    {
        Task<List<Factory>> GetAllFactories();
        Task Save(List<Factory> factories);

        Task<Factory?> GetFactoryByExternalId(int factoryExternalId);
        Task<List<Factory>> GetAllFactories(int userId);
    }
}
