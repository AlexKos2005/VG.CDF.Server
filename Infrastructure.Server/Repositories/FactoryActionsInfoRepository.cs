using BreadCommunityWeb.Blz.Application.Interfaces.Repositories;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Repositories
{
    public class FactoryActionsInfoRepository : IFactoryActionsInfoRepository
    {
        private readonly SqlDataContext _sqlDataContext;

        public FactoryActionsInfoRepository(SqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
        public async Task Delete(int id)
        {
            var factoryActions = await _sqlDataContext.FactoryActionsInfos.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (factoryActions == null)
            {
                return;
            }

            _sqlDataContext.FactoryActionsInfos.Remove(factoryActions);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<FactoryActionsInfo> Get(int id)
        {
            return await _sqlDataContext.FactoryActionsInfos.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<FactoryActionsInfo?> GetByFactoryExternalId(int factoryExternalId)
        {
            var factory = await _sqlDataContext.Factories.Where(c => c.ExternalId == factoryExternalId).FirstOrDefaultAsync();
            if(factory == null)
            {
                return null;
            }

            var factoryActions = await _sqlDataContext.FactoryActionsInfos.Where(c => c.FactoryId == factory.Id).FirstOrDefaultAsync();

            return factoryActions;
        }

        public async Task Save(FactoryActionsInfo entity)
        {
            _sqlDataContext.FactoryActionsInfos.Add(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<FactoryActionsInfo> Update(int id, FactoryActionsInfo entity)
        {
            var factoryActions = await _sqlDataContext.FactoryActionsInfos.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (factoryActions == null)
            {
                return null;
            }

            factoryActions.LastDateTimeConnection = entity.LastDateTimeConnection;
            factoryActions.LastDateTimeReportSending = entity.LastDateTimeReportSending;

            _sqlDataContext.FactoryActionsInfos.Update(factoryActions);
            await _sqlDataContext.SaveChangesAsync();

            return factoryActions;
        }
    }
}
