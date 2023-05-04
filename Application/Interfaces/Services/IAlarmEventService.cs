using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface IAlarmEventService : ICrudService<AlarmEventRequestDto, AlarmEventResponseDto,int>
    {
        Task<AlarmEventResponseDto?> GetByExternalId(int alarmEventExternalId);
        Task Save(List<AlarmEventRequestDto> alarmEvents);

        Task<List<AlarmEventRequestDto>> GetAll();

        Task AddDescriptionById(int alarmEventId, AlarmEventDescriptionRequestDto alarmEventDescription);

        Task AddDescriptionByExternalId(int alarmEventExternalId, AlarmEventDescriptionRequestDto alarmEventDescription);

        Task DeleteDescription(int alarmEventId, int alarmEventDescriptionId);

        Task<List<AlarmEventDescriptionResponseDto>> GetDescriptions(int alarmEventId);

        Task<List<AlarmEventDescriptionResponseDto>> GetDescriptionsByExtenalId(int externalId);
    }
}
