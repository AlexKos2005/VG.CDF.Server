
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Infrastructure.Repositories
{
    public class TagParamDescriptionRepository : ITagParamDescriptionRepository
    {
        private readonly ISqlDataContext _sqlDataContext;

        public TagParamDescriptionRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
        public async Task Delete(int id)
        {
            var tagDescription = await _sqlDataContext.TagParamDescriptions.Where(c=>c.Id == id).FirstOrDefaultAsync();
             _sqlDataContext.TagParamDescriptions.Remove(tagDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<ParameterDescription?> Get(int id)
        {
            return await _sqlDataContext.TagParamDescriptions.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ParameterDescription?> Get(int tagParamId, int languageId)
        {
            return await _sqlDataContext.TagParamDescriptions.Where(c => c.ParameterId == tagParamId && c.LanguageId == languageId).FirstOrDefaultAsync();
        }

        public async Task<List<ParameterDescription>> GetAll()
        {
            return await _sqlDataContext.TagParamDescriptions.ToListAsync();
        }

        public async Task<List<ParameterDescription>> GetAllByExternalId(int tagParamExternalId)
        {
            return await _sqlDataContext.TagParamDescriptions.Where(c => c.Parameter.ExternalId == tagParamExternalId).ToListAsync();
        }

        public async Task<Language> GetLanguage(int tagDescriptionId)
        {
            return await _sqlDataContext.TagParamDescriptions.Where(c => c.Id == tagDescriptionId).Select(s => s.DescriptionsLanguage).FirstOrDefaultAsync();
        }

        public async Task Save(ParameterDescription entity)
        {
            await _sqlDataContext.TagParamDescriptions.AddAsync(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Save(List<ParameterDescription> tagDescriptions)
        {
            await _sqlDataContext.TagParamDescriptions.AddRangeAsync(tagDescriptions);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<ParameterDescription?> Update(int id, ParameterDescription entity)
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
