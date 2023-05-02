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
