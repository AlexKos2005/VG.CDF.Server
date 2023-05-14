﻿
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Infrastructure.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ISqlDataContext _sqlDataContext;
        public LanguageRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }

        public async Task AddAlarmEventDescription(int languageId, AlarmEventDescription alarmEventDescription)
        {
            var language = await _sqlDataContext.DescriptionsLanguages.Where(c => c.Id == languageId).FirstOrDefaultAsync();
            language.AlarmEventDescription.Add(alarmEventDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task AddDeviceDescription(int languageId, ProcessDescription processDescription)
        {
            var language = await _sqlDataContext.DescriptionsLanguages.Where(c => c.Id == languageId).FirstOrDefaultAsync();
            language.DeviceDescriptions.Add(processDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task AddTagDescription(int languageId, ParameterDescription tagDescription)
        {
            var language = await _sqlDataContext.DescriptionsLanguages.Where(c => c.Id == languageId).FirstOrDefaultAsync();
            language.TagDescriptions.Add(tagDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var language = await _sqlDataContext.DescriptionsLanguages.Where(c => c.Id == id).FirstOrDefaultAsync();
            if(language == null)
            {
                return;
            }

            _sqlDataContext.DescriptionsLanguages.Remove(language);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task DeleteAlarmEventDescription(int languageId, int alarmEventDescriptionId)
        {
            var language = await _sqlDataContext.DescriptionsLanguages.Where(c => c.Id == languageId).FirstOrDefaultAsync();
            var alarmEventDesc = await _sqlDataContext.AlarmEventDescriptions.Where(c => c.Id == alarmEventDescriptionId).FirstOrDefaultAsync();
            language.AlarmEventDescription.Remove(alarmEventDesc);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task DeleteDeviceDescription(int languageId, int deviceDescriptionId)
        {
            var language = await _sqlDataContext.DescriptionsLanguages.Where(c => c.Id == languageId).FirstOrDefaultAsync();
            var deviceDesc = await _sqlDataContext.DeviceDescriptions.Where(c => c.Id == deviceDescriptionId).FirstOrDefaultAsync();
            language.DeviceDescriptions.Remove(deviceDesc);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task DeleteTagDescription(int languageId, int tagDescriptionId)
        {
            var language = await _sqlDataContext.DescriptionsLanguages.Where(c => c.Id == languageId).FirstOrDefaultAsync();
            var tagDesc = await _sqlDataContext.TagParamDescriptions.Where(c => c.Id == tagDescriptionId).FirstOrDefaultAsync();
            language.TagDescriptions.Remove(tagDesc);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<Language?> Get(int id)
        {
            return await _sqlDataContext.DescriptionsLanguages.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Language>> GetAll()
        {
          return await _sqlDataContext.DescriptionsLanguages.ToListAsync();
        }

        public async Task<Language?> GetByExternalId(int languageExternalId)
        {
            return await _sqlDataContext.DescriptionsLanguages.Where(c => c.ExternalId == languageExternalId).FirstOrDefaultAsync();
        }

        public async Task Save(Language entity)
        {
            await _sqlDataContext.DescriptionsLanguages.AddAsync(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<Language?> Update(int id, Language entity)
        {
            var language = await _sqlDataContext.DescriptionsLanguages.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (language == null)
            {
                return null;
            }

            language.LanguageLabel = entity.Acronym;

            _sqlDataContext.DescriptionsLanguages.Update(language);
            await _sqlDataContext.SaveChangesAsync();

            return language;
        }
    }
}
