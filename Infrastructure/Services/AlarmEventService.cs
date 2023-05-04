using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BreadCommunityWeb.Blz.Infrastructure.Server.Repositories;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Infrastructure.Configurations;
using VG.CDF.Server.Infrastructure.DataContext;

namespace VG.CDF.Server.Infrastructure.Services
{
    public class AlarmEventService : IAlarmEventService
    {

        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public AlarmEventService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            await alarmEventRepository.Delete(id);
        }

        public async Task<AlarmEventResponseDto?> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            var result = await alarmEventRepository.Get(id);
            if(result == null)
            {
                return null;
            }
            return _mapper.Map<AlarmEventResponseDto>(result);
        }


        public async Task Save(AlarmEventRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            await alarmEventRepository.Save(_mapper.Map<AlarmEvent>(entity));
        }

        public async Task<AlarmEventResponseDto?> Update(int id, AlarmEventRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            var result = await alarmEventRepository.Update(id, _mapper.Map<AlarmEvent>(entity));
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<AlarmEventResponseDto>(result);
        }

        public async Task Save(List<AlarmEventRequestDto> alarmEvents)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            await alarmEventRepository.Save(_mapper.Map<List<AlarmEvent>>(alarmEvents));
        }

        public async Task AddDescriptionById(int alarmEventId, AlarmEventDescriptionRequestDto alarmEventDescription)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            var alarmEventDesc = _mapper.Map<AlarmEventDescription>(alarmEventDescription);
            alarmEventDesc.AlarmEventId = alarmEventId;
            await alarmEventRepository.AddDescriptionById(alarmEventId,alarmEventDesc);
        }

        public async Task DeleteDescription(int alarmEventId, int alarmEventDescriptionId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            var alarmEvent = await alarmEventRepository.Get(alarmEventId);
            await alarmEventRepository.DeleteDescription(alarmEventId, alarmEventDescriptionId);

        }

        public async Task<List<AlarmEventRequestDto>> GetAll()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            return _mapper.Map<List<AlarmEventRequestDto>>(await alarmEventRepository.GetAll());
        }

        public async Task<List<AlarmEventDescriptionResponseDto>> GetDescriptions(int alarmEventId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            var alarmEventDescriptions = await alarmEventRepository.GetDescriptions(alarmEventId);

            return _mapper.Map<List<AlarmEventDescriptionResponseDto>>(alarmEventDescriptions);
        }

        public async Task<AlarmEventResponseDto?> GetByExternalId(int alarmEventExternalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            var result = await alarmEventRepository.GetByExternalId(alarmEventExternalId);
            if (result == null)
            {
                return null;
            }

            return _mapper.Map<AlarmEventResponseDto>(result);
        }

        public async Task<List<AlarmEventDescriptionResponseDto>> GetDescriptionsByExtenalId(int externalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            return _mapper.Map<List<AlarmEventDescriptionResponseDto>>(await alarmEventRepository.GetDescriptionsByExtenalId(externalId));
        }

        public async Task AddDescriptionByExternalId(int alarmEventExternalId, AlarmEventDescriptionRequestDto alarmEventDescription)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventRepository = new AlarmEventRepository(db);
            var alarmEventDesc = _mapper.Map<AlarmEventDescription>(alarmEventDescription);
            await alarmEventRepository.AddDescriptionByExternalId(alarmEventExternalId, alarmEventDesc);
        }

        
    }
}
