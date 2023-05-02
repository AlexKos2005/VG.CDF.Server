using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
    public interface IDeviceService : ICrudService<DeviceRequestDto, DeviceResponseDto,int>
    {
        Task Save(List<DeviceRequestDto> devices);

        Task<List<DeviceResponseDto>> GetAll();
        Task<List<DeviceResponseDto>> GetAllByFactoryId(int factoryId);

        Task<List<DeviceResponseDto>> GetAllByFactoryExternalId(int factoryExternalId);

        Task<DeviceResponseDto?> GetByExternalId(int externalId);

        Task<List<TagParamResponseDto>> GetTagParamsForDevice(int externalId);


        Task AddTagParamsToDevice(int deviceExternalId, List<int> tagparamsExternalId);

        Task AddDescriptionById(int deviceId, DeviceDescriptionRequestDto deviceDescription);

        Task AddDescriptionByExternalId(int deviceExternalId, DeviceDescriptionRequestDto deviceDescription);

        Task DeleteDescription(int deviceId, int deviceDescriptionId);

        Task<List<DeviceDescriptionResponseDto>> GetDescriptions(int deviceId);

        Task<List<DeviceDescriptionResponseDto>> GetDescriptionsByExtenalId(int externalId);


    }
}
