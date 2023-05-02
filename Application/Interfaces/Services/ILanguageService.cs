using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
    public interface ILanguageService : ICrudService<DescriptionsLanguageRequestDto,LanguageResponseDto,int>
    {
        Task<List<LanguageResponseDto>> GetAll();

        Task<LanguageResponseDto?> GetByExternalId(int languageExternalId);
        Task AddTagDescription(int languageId, TagParamDescriptionRequestDto tagDescription);
        Task DeleteTagDescription(int languageId, int tagDescriptionId);

        Task AddDeviceDescription(int languageId, DeviceDescriptionRequestDto deviceDescription);
        Task DeleteDeviceDescription(int languageId, int deviceDescriptionId);

        Task AddAlarmEventDescription(int languageId, AlarmEventDescriptionRequestDto alarmEventDescription);
        Task DeleteAlarmEventDescription(int languageId, int alarmEventDescriptionId);
    }
}
