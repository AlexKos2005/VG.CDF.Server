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
    public interface IAlarmEventLiveService : ICrudService<AlarmEventLiveRequestDto, AlarmEventLiveResponseDto,long>
    {
        Task<List<AlarmEventLiveResponseDto>> GetAlarmEventsLive(int factoryExternalId, DateTime startDate, DateTime endDate);

        Task<List<AlarmEventLiveResponseDto>> GetAlarmEventsLive(int externalId, int factoryExternalId, DateTime startDate, DateTime endDate);

        Task<List<AlarmEventLiveResponseDto>> GetAlarmEventsByFactoryExternalIdAndDeviceExternalId(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate);

        Task Save(List<AlarmEventLiveRequestDto> alarmEventLives);
    }
}
