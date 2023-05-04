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
    public class AlarmEventDescriptionService : IAlarmEventDescriptionService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public AlarmEventDescriptionService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventDescriptionRepository = new AlarmEventDescriptionRepository(db);
            await alarmEventDescriptionRepository.Delete(id);
        }

        public async Task<AlarmEventDescriptionResponseDto?> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventDescriptionRepository = new AlarmEventDescriptionRepository(db);
            var result = await alarmEventDescriptionRepository.Get(id);
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<AlarmEventDescriptionResponseDto>(result);
        }

        public async Task<List<AlarmEventDescriptionResponseDto>> GetAll()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventDescriptionRepository = new AlarmEventDescriptionRepository(db);
            var result = await alarmEventDescriptionRepository.GetAll();
            return _mapper.Map<List<AlarmEventDescriptionResponseDto>>(result);
        }

        public async Task<LanguageResponseDto?> GetLanguage(int alarmEventDescriptionId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventDescriptionRepository = new AlarmEventDescriptionRepository(db);
            var result = await alarmEventDescriptionRepository.GetLanguage(alarmEventDescriptionId);
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<LanguageResponseDto>(result);

        }

        public async Task Save(List<AlarmEventDescriptionRequestDto> alarmEventDescriptions)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventDescriptionRepository = new AlarmEventDescriptionRepository(db);
            await alarmEventDescriptionRepository.Save(_mapper.Map<List<AlarmEventDescription>>(alarmEventDescriptions));
        }

        public async Task Save(AlarmEventDescriptionRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventDescriptionRepository = new AlarmEventDescriptionRepository(db);
            await alarmEventDescriptionRepository.Save(_mapper.Map<AlarmEventDescription>(entity));
        }

        public async Task<AlarmEventDescriptionResponseDto?> Update(int id, AlarmEventDescriptionRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventDescriptionRepository = new AlarmEventDescriptionRepository(db);
            var result = await alarmEventDescriptionRepository.Update(id, _mapper.Map<AlarmEventDescription>(entity));
            if (result == null)
            {
                return null;
            }

            return _mapper.Map<AlarmEventDescriptionResponseDto>(result);
        }
    }
}
