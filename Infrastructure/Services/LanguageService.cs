using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Infrastructure.Configurations;
using VG.CDF.Server.Infrastructure.DataContext;
using VG.CDF.Server.Infrastructure.Repositories;

namespace VG.CDF.Server.Infrastructure.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public LanguageService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }
        public async Task AddAlarmEventDescription(int languageId, AlarmEventDescriptionRequestDto alarmEventDescription)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            await languageRepository.AddAlarmEventDescription(languageId, _mapper.Map<AlarmEventDescription>(alarmEventDescription));
        }

        public async Task AddDeviceDescription(int languageId, DeviceDescriptionRequestDto deviceDescription)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            await languageRepository.AddDeviceDescription(languageId, _mapper.Map<ProcessDescription>(deviceDescription));
        }

        public async Task AddTagDescription(int languageId, TagParamDescriptionRequestDto tagDescription)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            await languageRepository.AddTagDescription(languageId, _mapper.Map<ParameterDescription>(tagDescription));
        }

        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            await languageRepository.Delete(id);
        }

        public async Task DeleteAlarmEventDescription(int languageId, int alarmEventDescriptionId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            await languageRepository.DeleteAlarmEventDescription(languageId, alarmEventDescriptionId);
        }

        public async Task DeleteDeviceDescription(int languageId, int deviceDescriptionId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            await languageRepository.DeleteDeviceDescription(languageId, deviceDescriptionId);
        }

        public async Task DeleteTagDescription(int languageId, int tagDescriptionId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            await languageRepository.DeleteTagDescription(languageId, tagDescriptionId);
        }

        public async Task<LanguageResponseDto?> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            var result = await languageRepository.Get(id);
            if(result == null)
            {
                return null;
            }
            return _mapper.Map<LanguageResponseDto>(result);
        }

        public async Task<List<LanguageResponseDto>> GetAll()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            return _mapper.Map<List<LanguageResponseDto>>(await languageRepository.GetAll());
        }

        public async Task<LanguageResponseDto?> GetByExternalId(int languageExternalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            return _mapper.Map<LanguageResponseDto>(await languageRepository.GetByExternalId(languageExternalId));
        }

        public async Task Save(DescriptionsLanguageRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            await languageRepository.Save(_mapper.Map<DescriptionsLanguage>(entity));
        }

        public async Task<LanguageResponseDto?> Update(int id, DescriptionsLanguageRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var languageRepository = new LanguageRepository(db);
            var result = await languageRepository.Update(id, _mapper.Map<DescriptionsLanguage>(entity));
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<LanguageResponseDto>(result);
        }
    }
}
