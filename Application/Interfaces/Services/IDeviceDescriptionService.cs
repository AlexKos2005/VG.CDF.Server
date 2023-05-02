using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
    public interface IDeviceDescriptionService : ICrudService<DeviceDescriptionRequestDto, DeviceDescriptionResponseDto,int>
    {
        Task Save(List<DeviceDescriptionRequestDto> deviceDescriptions);
        Task<List<DeviceDescriptionResponseDto>> GetAll();

        Task<List<DeviceDescriptionResponseDto>> GetAllDescriptionsByDeviceExternalId(int tagParamExternalId);
        Task<DeviceDescriptionResponseDto?> Get(int tagParamExternalId, int languageExternalId);

        Task<LanguageResponseDto?> GetLanguage(int deviceDescriptionId);
    }
}
