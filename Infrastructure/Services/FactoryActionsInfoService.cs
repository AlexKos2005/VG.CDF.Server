using System;
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
    public class FactoryActionsInfoService : IFactoryActionsInfoService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public FactoryActionsInfoService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryActionsInfoRepository = new FactoryActionsInfoRepository(db);
            await factoryActionsInfoRepository.Delete(id);
        }

        public async Task<FactoryActionsInfoResponseDto> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryActionsInfoRepository = new FactoryActionsInfoRepository(db);
            var result = await factoryActionsInfoRepository.Get(id);
            return _mapper.Map<FactoryActionsInfoResponseDto>(result);
        }

        public async Task<FactoryActionsInfoResponseDto?> GetByFactoryExternalId(int factoryExternalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryActionsInfoRepository = new FactoryActionsInfoRepository(db);
            var result = await factoryActionsInfoRepository.GetByFactoryExternalId(factoryExternalId);
            if (result == null)
            {
                return null;
            }

            return _mapper.Map<FactoryActionsInfoResponseDto>(result);
        }

        public async Task ChangeLastDateTimeConnection(int factoryExternalId, DateTime dateTime, DateTimeOffset dateTimeOffset)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryActionsInfoRepository = new FactoryActionsInfoRepository(db);
            var factoryActionsInfo = await factoryActionsInfoRepository.GetByFactoryExternalId(factoryExternalId);
            if(factoryActionsInfo == null)
            {
                return;
            }

            factoryActionsInfo.LastDateTimeConnection = dateTime;
            factoryActionsInfo.LastDateTimeConnectionOffset = dateTimeOffset;

            await factoryActionsInfoRepository.Update(factoryActionsInfo.Id, factoryActionsInfo);
        }

        public async Task ChangeLastDateTimeReportSending(int factoryExternalId, DateTime dateTime, DateTimeOffset dateTimeOffset)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryActionsInfoRepository = new FactoryActionsInfoRepository(db);
            var factoryActionsInfo = await factoryActionsInfoRepository.GetByFactoryExternalId(factoryExternalId);
            if (factoryActionsInfo == null)
            {
                return;
            }

            factoryActionsInfo.LastDateTimeReportSending = dateTime;
            factoryActionsInfo.LastDateTimeReportSendingOffset = dateTimeOffset;

            await factoryActionsInfoRepository.Update(factoryActionsInfo.Id, factoryActionsInfo);
        }

        public async Task Save(FactoryActionsInfoRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryActionsInfoRepository = new FactoryActionsInfoRepository(db);
            await factoryActionsInfoRepository.Save(_mapper.Map<FactoryActionsInfo>(entity));
        }

        public async Task<FactoryActionsInfoResponseDto> Update(int id, FactoryActionsInfoRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryActionsInfoRepository = new FactoryActionsInfoRepository(db);
            var result = await factoryActionsInfoRepository.Update(id, _mapper.Map<FactoryActionsInfo>(entity));

            return _mapper.Map<FactoryActionsInfoResponseDto>(result);
        }
    }
}
