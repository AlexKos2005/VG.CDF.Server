using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
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
