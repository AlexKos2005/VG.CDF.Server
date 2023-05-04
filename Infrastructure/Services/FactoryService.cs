using System;
using System.Collections.Generic;
using System.Linq;
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
    public class FactoryService : IFactoryService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public FactoryService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryRepository = new FactoryRepository(db);
            await factoryRepository.Delete(id);
        }

        public async Task<FactoryResponseDto?> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryRepository = new FactoryRepository(db);
            var result = await factoryRepository.Get(id);
            return _mapper.Map<FactoryResponseDto>(result);
        }

        public async Task<List<FactoryResponseDto>> GetAllFactories()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);

            var tt = db.TagReportTasks.ToList();
            
            var factoryRepository = new FactoryRepository(db);
            var result = await factoryRepository.GetAllFactories();
            return _mapper.Map<List<FactoryResponseDto>>(result);
        }

        public async Task<List<FactoryResponseDto>> GetAllFactories(int userId)
        {
            var factoryList = new List<Factory>();
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryRepository = new FactoryRepository(db);
            var result = await factoryRepository.GetAllFactories(userId);
            foreach (var factory in result)
            {
                var gotFactory = await factoryRepository.GetFactoryByExternalId(factory.ExternalId);
                if(gotFactory!=null)
                {
                    factoryList.Add(gotFactory);
                }
                
            }

            return _mapper.Map<List<FactoryResponseDto>>(factoryList);
        }

        public async Task<FactoryResponseDto?> GetFactoryByExternalId(int factoryExternalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryRepository = new FactoryRepository(db);
            var result = await factoryRepository.GetFactoryByExternalId(factoryExternalId);
            return _mapper.Map<FactoryResponseDto>(result);
        }

        public async Task Save(FactoryRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryRepository = new FactoryRepository(db);
            await factoryRepository.Save(_mapper.Map<Factory>(entity));
            var factories = await factoryRepository.GetAllFactories();
            var factory = factories.Where(c => c.ExternalId == entity.ExternalId).FirstOrDefault();
            if(factory == null)
            {
                return;
            }

            var factoryActionsInfoRepository = new FactoryActionsInfoRepository(db);
            var currentFactoryActionsInfo = await factoryActionsInfoRepository.GetByFactoryExternalId(entity.ExternalId);
            if(currentFactoryActionsInfo == null)
            {
                var factoryActionsInfo = new FactoryActionsInfo()
                {
                    AlarmMessageCounter = 0,
                    LastDateTimeConnection = new DateTime(),
                    LastDateTimeConnectionOffset = new DateTimeOffset(),
                    LastDateTimeReportSending = new DateTime(),
                    LastDateTimeReportSendingOffset = new DateTimeOffset(),
                    FactoryId = factory.Id
                };

                await factoryActionsInfoRepository.Save(factoryActionsInfo);
            }

        }
        public async Task<FactoryResponseDto> Update(int id, FactoryRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryRepository = new FactoryRepository(db);
            var result = await factoryRepository.Update(id, _mapper.Map<Factory>(entity));

            return _mapper.Map<FactoryResponseDto>(result);
        }
    }
}
