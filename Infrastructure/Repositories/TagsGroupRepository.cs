
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Infrastructure.Repositories
{
    public class TagsGroupRepository : ITagsGroupRepository
    {
        private readonly ISqlDataContext _sqlDataContext;

        public TagsGroupRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
        public async Task Delete(long id)
        {
            var tagsGroup = await _sqlDataContext.TagsGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (tagsGroup == null)
            {
                return;
            }

            _sqlDataContext.TagsGroups.Remove(tagsGroup);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<ParameterValuesGroup> Get(long id)
        {
            return await _sqlDataContext.TagsGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ParameterValuesGroup>> Get(int factoryExternalId, DateTime date)
        {
            return await _sqlDataContext.TagsGroups.Where(c => c.ProjectExternalId == factoryExternalId && c.DateTimeOffset.UtcDateTime == date).ToListAsync();
        }

        public async Task<List<ParameterValuesGroup>> Get(int factoryExternalId, int deviceExternalId, DateTime date)
        {
            return await _sqlDataContext.TagsGroups.Where(c => c.ProjectExternalId == factoryExternalId && c.ProcessExternalId == deviceExternalId && c.DateTimeOffset.UtcDateTime == date).ToListAsync();
        }

        public async Task<List<ParameterValuesGroup>> Get(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate)
        {
           return await _sqlDataContext.TagsGroups.Where(c => c.ProjectExternalId == factoryExternalId
           && c.ProcessExternalId == deviceExternalId && c.DateTime.Date >= startDate.Date && c.DateTime.Date <= endDate.Date)
           .Include(c=>c.ParameterValues)
           .OrderBy(c => c.DateTime)
           .ToListAsync();   
        }

        public async Task<List<ParameterValuesGroup>> GetAllTagsGroup()
        {
            return await _sqlDataContext.TagsGroups.ToListAsync();
        }

        public async Task Save(ParameterValuesGroup entity)
        {
            _sqlDataContext.TagsGroups.Add(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task SaveGroups(List<ParameterValuesGroup> tagsGroups)
        {
            _sqlDataContext.TagsGroups.AddRange(tagsGroups);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<ParameterValuesGroup?> Update(long id, ParameterValuesGroup entity)
        {
            var tagsGroup = await _sqlDataContext.TagsGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (tagsGroup == null)
            {
                return null;
            }

            tagsGroup = entity;

            _sqlDataContext.TagsGroups.Update(tagsGroup);
            await _sqlDataContext.SaveChangesAsync();

            return tagsGroup;
        }
    }
}
