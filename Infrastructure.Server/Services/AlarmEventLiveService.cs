using AutoMapper;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Infrastructure.Server.Configurations;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using BreadCommunityWeb.Blz.Infrastructure.Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Services
{
    public class AlarmEventLiveService : IAlarmEventLiveService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public AlarmEventLiveService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }
        public async Task Delete(long id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventLiveRepository = new AlarmEventLiveRepository(db);
            await alarmEventLiveRepository.Delete(id);
        }

        public async Task<AlarmEventLiveResponseDto> Get(long id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventLiveRepository = new AlarmEventLiveRepository(db);
            var result = await alarmEventLiveRepository.Get(id);
            return _mapper.Map<AlarmEventLiveResponseDto>(result);
        }

        public async Task<List<AlarmEventLiveResponseDto>> GetAlarmEventsByFactoryExternalIdAndDeviceExternalId(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventLiveRepository = new AlarmEventLiveRepository(db);
            var result = await alarmEventLiveRepository.GetAlarmEventsByFactoryExternalIdAndDeviceExternalId(factoryExternalId, deviceExternalId, startDate, endDate);

            return _mapper.Map<List<AlarmEventLiveResponseDto>>(result);
        }

        public async Task<List<AlarmEventLiveResponseDto>> GetAlarmEventsLive(int factoryExternalId, DateTime startDate, DateTime endDate)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventLiveRepository = new AlarmEventLiveRepository(db);
            var result = await alarmEventLiveRepository.GetAlarmEvents(factoryExternalId, startDate, endDate);

            return _mapper.Map<List<AlarmEventLiveResponseDto>>(result);

        }

        public async Task<List<AlarmEventLiveResponseDto>> GetAlarmEventsLive(int externalId, int factoryExternalId, DateTime startDate, DateTime endDate)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventLiveRepository = new AlarmEventLiveRepository(db);
            var result = await alarmEventLiveRepository.GetAlarmEvents(externalId, factoryExternalId, startDate, endDate);

            return _mapper.Map<List<AlarmEventLiveResponseDto>>(result);
        }

        public async Task Save(AlarmEventLiveRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventLiveRepository = new AlarmEventLiveRepository(db);
            await alarmEventLiveRepository.Save(_mapper.Map<AlarmEventLive>(entity));
        }

        public async Task Save(List<AlarmEventLiveRequestDto> alarmEventLives)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventLiveRepository = new AlarmEventLiveRepository(db);
            await alarmEventLiveRepository.Save(_mapper.Map<List<AlarmEventLive>>(alarmEventLives));
        }

        public async Task<AlarmEventLiveResponseDto> Update(long id, AlarmEventLiveRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var alarmEventLiveRepository = new AlarmEventLiveRepository(db);
            var result = await alarmEventLiveRepository.Update(id, _mapper.Map<AlarmEventLive>(entity));

            return _mapper.Map<AlarmEventLiveResponseDto>(result);
        }
    }
}
