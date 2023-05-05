using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Infrastructure.Configurations;
using VG.CDF.Server.Infrastructure.DataContext;
using VG.CDF.Server.Infrastructure.Repositories;

namespace VG.CDF.Server.Infrastructure.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IUserService _userService;
        private readonly IFactoryService _factoryService;
        private readonly IDeviceService _deviceService;
        private readonly ITagParamService _tagParamService;
        private readonly IMapper _mapper;
        public UserDataService(DbConnectionConfig dbConnectionConfig, IUserService userService, IFactoryService factoryService, IMapper mapper, IDeviceService deviceService, ITagParamService tagParamService)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _userService = userService;
            _factoryService = factoryService;
            _deviceService = deviceService;
            _tagParamService = tagParamService;
            _mapper = mapper;
        }
        public async Task<List<DeviceWithDescriptionsDto>> GetDevicesByFactoryId(int factoryId)
        {
            var dev = new List<Process>();
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryRepository = new FactoryRepository(db);
            var factory = await factoryRepository.Get(factoryId);
            dev = factory.Devices.ToList();

            var result = _mapper.Map<List<DeviceWithDescriptionsDto>>(dev);

            return result;
        }

        public async Task<List<TagParamWithDescriptions>> GetTagParamByDeviceId(int deviceId)
        {
            var tagsParamsDesc = new List<TagParamWithDescriptions>();
            var device = await _deviceService.Get(deviceId);
            if(device == null)
            {
                return new List<TagParamWithDescriptions>();
            }
            var tagParams = await _deviceService.GetTagParamsForDevice(device.ExternalId);

            foreach (var tagParam in tagParams)
            {
                var tagParamDesc = new TagParamWithDescriptions();
                var descriptions = await _tagParamService.GetDescriptions(tagParam.Id);

                tagParamDesc.Id = tagParam.Id;
                tagParamDesc.ExternalId = tagParam.ExternalId;
                tagParamDesc.ParameterGroupId = tagParam.ParameterGroupId;
                tagParamDesc.ValueType = tagParam.ValueType;
                tagParamDesc.TagParamDescriptions.AddRange(_mapper.Map<List<DescriptionDto>>(descriptions));

                tagsParamsDesc.Add(tagParamDesc);
            }

            return tagsParamsDesc;
        }
    }
}
