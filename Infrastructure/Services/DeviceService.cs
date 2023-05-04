using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BreadCommunityWeb.Blz.Infrastructure.Server.Repositories;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Infrastructure.Configurations;
using VG.CDF.Server.Infrastructure.DataContext;
using VG.CDF.Server.Infrastructure.Repositories;

namespace VG.CDF.Server.Infrastructure.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public DeviceService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }

        public async Task AddDescriptionByExternalId(int deviceExternalId, DeviceDescriptionRequestDto deviceDescription)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            var devDesc = _mapper.Map<DeviceDescription>(deviceDescription);
            await deviceRepository.AddDescriptionByExternalId(deviceExternalId,devDesc);
        }

        public async Task AddDescriptionById(int deviceId, DeviceDescriptionRequestDto deviceDescription)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            var deviceDesc = _mapper.Map<DeviceDescription>(deviceDescription);
            deviceDesc.DeviceId = deviceId;
            await deviceRepository.AddDescriptionById(deviceId, deviceDesc);
        }

        public async Task AddTagParamsToDevice(int deviceExternalId, List<int> tagparamsExternalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            var tagparamsRepository = new TagParamRepository(db);

            var device = await deviceRepository.GetByExternalId(deviceExternalId);
            if(device == null)
            {
                return;
            }

            foreach (var tagParamExternalId in tagparamsExternalId)
            {
                var tagParam = await tagparamsRepository.GetByExternalId(tagParamExternalId);

                if(tagParam == null)
                {
                    continue;
                }

                await deviceRepository.AddTagParam(device.Id, tagParam);
            }

        }

        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            await deviceRepository.Delete(id);
        }

        public async Task DeleteDescription(int deviceId, int deviceDescriptionId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            var device = await deviceRepository.Get(deviceId);
            await deviceRepository.DeleteDescription(deviceId, deviceDescriptionId);
        }

        public async Task<DeviceResponseDto> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            var result = await deviceRepository.Get(id);
            return _mapper.Map<DeviceResponseDto>(result);
        }

        public async Task<List<DeviceResponseDto>> GetAll()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            return _mapper.Map<List<DeviceResponseDto>>(await deviceRepository.GetAll());
        }

        public async Task<List<DeviceResponseDto>> GetAllByFactoryExternalId(int factoryExternalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryRepository = new FactoryRepository(db);
            var factories = await factoryRepository.GetAllFactories();
            var factory = factories.Where(c => c.ExternalId == factoryExternalId).FirstOrDefault();
            if(factory == null)
            {
                return new List<DeviceResponseDto>();
            }

            var deviceRepository = new DeviceRepository(db);
            return _mapper.Map<List<DeviceResponseDto>>(await deviceRepository.GetAll(factory.Id));
        }

        public async Task<List<DeviceResponseDto>> GetAllByFactoryId(int factoryId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            var devices = await deviceRepository.GetAll(factoryId);
            var devicesDto = _mapper.Map<List<DeviceResponseDto>>(devices);
            return devicesDto;
        }

        public async Task<DeviceResponseDto?> GetByExternalId(int externalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            return _mapper.Map<DeviceResponseDto>(await deviceRepository.GetByExternalId(externalId));
        }

        public async Task<List<DeviceDescriptionResponseDto>> GetDescriptions(int deviceId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            var deviceDescriptions = await deviceRepository.GetDescriptions(deviceId);

            return _mapper.Map<List<DeviceDescriptionResponseDto>>(deviceDescriptions);
        }

        public async Task<List<TagParamResponseDto>> GetTagParamsForDevice(int externalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            var device = await deviceRepository.GetByExternalId(externalId);
            if (device == null)
            {
                return new List<TagParamResponseDto>();
            }
            var tagParamsDevices = await deviceRepository.GetTagParamsForDevice(device.Id);

            var tagParams = new List<TagParamResponseDto>();

            foreach (var tagParamsDevice in tagParamsDevices)
            {
                tagParams.Add(_mapper.Map<TagParamResponseDto>(tagParamsDevice.TagParam));
            }

            return tagParams;
        }

        public async Task<List<DeviceDescriptionResponseDto>> GetDescriptionsByExtenalId(int externalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
           var tt =_mapper.Map<List<DeviceDescriptionResponseDto>>(await deviceRepository.GetDescriptionsByExtenalId(externalId));

            return tt;
        }

        public async Task Save(List<DeviceRequestDto> devices)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            await deviceRepository.Save(_mapper.Map<List<Device>>(devices));
        }

        public async Task Save(DeviceRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            await deviceRepository.Save(_mapper.Map<Device>(entity));
        }

        public async Task<DeviceResponseDto> Update(int id, DeviceRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceRepository = new DeviceRepository(db);
            var result = await deviceRepository.Update(id, _mapper.Map<Device>(entity));

            return _mapper.Map<DeviceResponseDto>(result);
        }

       
    }
}
