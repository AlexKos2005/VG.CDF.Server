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
    public class TagsGroupRepository : ITagsGroupRepository
    {
        private readonly SqlDataContext _sqlDataContext;

        public TagsGroupRepository(SqlDataContext sqlDataContext)
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

        public async Task<TagsGroup> Get(long id)
        {
            return await _sqlDataContext.TagsGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<TagsGroup>> Get(int factoryExternalId, DateTime date)
        {
            return await _sqlDataContext.TagsGroups.Where(c => c.FactoryExternalId == factoryExternalId && c.DateTimeOffset.UtcDateTime == date).ToListAsync();
        }

        public async Task<List<TagsGroup>> Get(int factoryExternalId, int deviceExternalId, DateTime date)
        {
            return await _sqlDataContext.TagsGroups.Where(c => c.FactoryExternalId == factoryExternalId && c.DeviceExternalId == deviceExternalId && c.DateTimeOffset.UtcDateTime == date).ToListAsync();
        }

        public async Task<List<TagsGroup>> Get(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate)
        {
           return await _sqlDataContext.TagsGroups.Where(c => c.FactoryExternalId == factoryExternalId
           && c.DeviceExternalId == deviceExternalId && c.DateTime.Date >= startDate.Date && c.DateTime.Date <= endDate.Date)
           .Include(c=>c.TagsLive)
           .OrderBy(c => c.DateTime)
           .ToListAsync();   
        }

        public async Task<List<TagsGroup>> GetAllTagsGroup()
        {
            return await _sqlDataContext.TagsGroups.ToListAsync();
        }

        public async Task Save(TagsGroup entity)
        {
            _sqlDataContext.TagsGroups.Add(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task SaveGroups(List<TagsGroup> tagsGroups)
        {
            _sqlDataContext.TagsGroups.AddRange(tagsGroups);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<TagsGroup?> Update(long id, TagsGroup entity)
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
