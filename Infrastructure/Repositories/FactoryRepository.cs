﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Infrastructure.Repositories
{
    public class FactoryRepository : IFactoryRepository
    {
        private readonly ISqlDataContext _dataContext;

        public FactoryRepository(ISqlDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Project>> GetAllFactories()
        {
            return await _dataContext.Factories.ToListAsync();
        }

        public async Task Save(List<Project> factories)
        {
            _dataContext.Factories.AddRange(factories);
            await _dataContext.SaveChangesAsync();
        }

        #region CRUD
        public async Task Save(Project entity)
        {
            _dataContext.Factories.Add(entity);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<Project?> Update(int id, Project entity)
        {
            var factory = await _dataContext.Factories.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (factory == null)
            {
                return null;
            }

            factory.Description = entity.Description;
            factory.ExternalId = entity.ExternalId;
            factory.UtcOffset = entity.UtcOffset;

            _dataContext.Factories.Update(factory);
            await _dataContext.SaveChangesAsync();

            return factory;
        }

        public async Task Delete(int id)
        {
            var factory = await _dataContext.Factories.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (factory == null)
            {
                return;
            }

            _dataContext.Factories.Remove(factory);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Project> Get(int id)
        {
            return await _dataContext.Factories.Where(c => c.Id == id).Include(c=>c.Devices).ThenInclude(c=>c.DeviceDescriptions).ThenInclude(c=>c.DescriptionsLanguage).FirstOrDefaultAsync();
        }

        public async Task<List<Project>> GetAllFactories(int userId)
        {
            var factories = await _dataContext.UsersFactories.Where(c=>c.UserId == userId).Select(s=>s.Project).ToListAsync();
            return factories;
        }

        public async Task<Project?> GetFactoryByExternalId(int factoryExternalId)
        {
            return await _dataContext.Factories.Where(c => c.ExternalId == factoryExternalId).Include(c=>c.ProjectActionsInfo).FirstOrDefaultAsync();
        }
        #endregion

    }
}
