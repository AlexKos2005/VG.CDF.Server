
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
    public class TagsLiveRepository : ITagsLiveRepository
    {
        private readonly ISqlDataContext _sqlDataContext;

        public TagsLiveRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }

        public async Task<List<ParameterValue>> GetByTagsGroup(long tagsGroupId)
        {
            return await _sqlDataContext.TagsLive.Where(c => c.ParameterValuesGroup.Id == tagsGroupId).ToListAsync();
        }
        public async Task Save(List<ParameterValue> tagsLives)
        {
            _sqlDataContext.TagsLive.AddRange(tagsLives);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var tagsLive = await _sqlDataContext.TagsLive.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (tagsLive == null)
            {
                return;
            }

            _sqlDataContext.TagsLive.Remove(tagsLive);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<ParameterValue?> Get(long id)
        {
            return await _sqlDataContext.TagsLive.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task Save(ParameterValue entity)
        {
            _sqlDataContext.TagsLive.Add(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<ParameterValue?> Update(long id, ParameterValue entity)
        {
            var tagsLive = await _sqlDataContext.TagsLive.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (tagsLive == null)
            {
                return null;
            }

            tagsLive = entity;

            _sqlDataContext.TagsLive.Update(tagsLive);
            await _sqlDataContext.SaveChangesAsync();

            return tagsLive;
        }

        public async Task<List<ParameterValue>> GetAllTagsLive()
        {
            return await _sqlDataContext.TagsLive.ToListAsync();
        }

        public async Task<List<ParameterValue>> Get(int factoryExternalId, int deviceExternalId, DateTime date)
        {
            return await _sqlDataContext.TagsLive.Where(
                c => c.ProjectId == factoryExternalId
                && c.ProcessId == deviceExternalId
                && c.DateTime.Date == date.Date).ToListAsync();

        }

        public async Task<List<ParameterValue>> Get(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate)
        {
            var res = await _sqlDataContext.TagsLive.Where(
                c => c.ProjectId == factoryExternalId
                && c.ProcessId == deviceExternalId
                && c.DateTime >= startDate
                && c.DateTime <= endDate).ToListAsync();

            return res;
        }
    }
}
