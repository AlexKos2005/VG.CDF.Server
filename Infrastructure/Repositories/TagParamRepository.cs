
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Infrastructure.Repositories
{
    public class TagParamRepository : ITagParamRepository
    {
        private readonly ISqlDataContext _sqlDataContext;

        public TagParamRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }

        public async Task AddDescriptionByExternalId(int tagParamExternalId, TagParamDescription taglangDescription)
        {
            var tagParam = await _sqlDataContext.TagParams.Where(c => c.ExternalId == tagParamExternalId).FirstOrDefaultAsync();
            if (tagParam == null)
            {
                return;
            }

            tagParam.TagDescriptions.Add(taglangDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task AddDescriptionById(int tagDescriptionId, TagParamDescription tagLanguageDescription)
        {
            var tagDescription = await _sqlDataContext.TagParams.Where(c => c.Id == tagDescriptionId).FirstOrDefaultAsync();
            if (tagDescription == null)
            {
                return;
            }

            tagDescription.TagDescriptions.Add(tagLanguageDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var tagDescription = await _sqlDataContext.TagParams.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (tagDescription == null)
            {
                return;
            }

            _sqlDataContext.TagParams.Remove(tagDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<TagParam?> Get(int id)
        {
            return await _sqlDataContext.TagParams.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<TagParam>> GetAll()
        {
            return await _sqlDataContext.TagParams.ToListAsync();
        }

        public async Task<TagParam?> GetByExternalId(int tagParamExternalId)
        {
            return await _sqlDataContext.TagParams.Where(c => c.ExternalId == tagParamExternalId).FirstOrDefaultAsync();
        }

        public async Task<List<TagParamDescription>> GetDescriptions(int tagId)
        {
            return await _sqlDataContext.TagParamDescriptions.Where(c => c.TagParamId == tagId).Include(c => c.DescriptionsLanguage).ToListAsync();
        }

        public async Task<List<TagParamDescription>> GetDescriptionsByExtenalId(int externalId)
        {
            return await _sqlDataContext.TagParamDescriptions.Where(c => c.TagParam.ExternalId == externalId).Include(c => c.DescriptionsLanguage).ToListAsync();
        }

        public async Task<List<TagParamDescription>> GetLanguageDescriptions(int tagDescriptionId)
        {
            return await _sqlDataContext.TagParamDescriptions.Where(c => c.TagParamId == tagDescriptionId).ToListAsync();
        }

        public async Task Save(TagParam entity)
        {
            _sqlDataContext.TagParams.Add(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Save(List<TagParam> tagDescriptions)
        {
            _sqlDataContext.TagParams.AddRange(tagDescriptions);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<TagParam?> Update(int id, TagParam entity)
        {
            var tag = await _sqlDataContext.TagParams.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (tag == null)
            {
                return null;
            }

            tag.TagDescriptions = entity.TagDescriptions;
            tag.ExternalId = entity.ExternalId;
            tag.ValueType = entity.ValueType;

            _sqlDataContext.TagParams.Update(tag);
            await _sqlDataContext.SaveChangesAsync();

            return tag;
        }
    }
}
