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
    public class TagParamDescriptionRepository : ITagParamDescriptionRepository
    {
        private readonly SqlDataContext _sqlDataContext;

        public TagParamDescriptionRepository(SqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
        public async Task Delete(int id)
        {
            var tagDescription = await _sqlDataContext.TagParamDescriptions.Where(c=>c.Id == id).FirstOrDefaultAsync();
             _sqlDataContext.TagParamDescriptions.Remove(tagDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<TagParamDescription?> Get(int id)
        {
            return await _sqlDataContext.TagParamDescriptions.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TagParamDescription?> Get(int tagParamId, int languageId)
        {
            return await _sqlDataContext.TagParamDescriptions.Where(c => c.TagParamId == tagParamId && c.DescriptionsLanguageId == languageId).FirstOrDefaultAsync();
        }

        public async Task<List<TagParamDescription>> GetAll()
        {
            return await _sqlDataContext.TagParamDescriptions.ToListAsync();
        }

        public async Task<List<TagParamDescription>> GetAllByExternalId(int tagParamExternalId)
        {
            return await _sqlDataContext.TagParamDescriptions.Where(c => c.TagParam.ExternalId == tagParamExternalId).ToListAsync();
        }

        public async Task<DescriptionsLanguage> GetLanguage(int tagDescriptionId)
        {
            return await _sqlDataContext.TagParamDescriptions.Where(c => c.Id == tagDescriptionId).Select(s => s.DescriptionsLanguage).FirstOrDefaultAsync();
        }

        public async Task Save(TagParamDescription entity)
        {
            await _sqlDataContext.TagParamDescriptions.AddAsync(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Save(List<TagParamDescription> tagDescriptions)
        {
            await _sqlDataContext.AddRangeAsync(tagDescriptions);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<TagParamDescription?> Update(int id, TagParamDescription entity)
        {
            var tagDescription = await _sqlDataContext.TagParamDescriptions.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (tagDescription == null)
            {
                return null;
            }

            tagDescription.Description= entity.Description;

            _sqlDataContext.TagParamDescriptions.Update(tagDescription);
            await _sqlDataContext.SaveChangesAsync();

            return tagDescription;
        }
    }
}
