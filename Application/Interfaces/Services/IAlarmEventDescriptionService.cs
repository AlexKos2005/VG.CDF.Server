using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
    public interface IAlarmEventDescriptionService : ICrudService<AlarmEventDescriptionRequestDto, AlarmEventDescriptionResponseDto, int>
    {
        Task Save(List<AlarmEventDescriptionRequestDto> alarmEventDescriptions);
        Task<List<AlarmEventDescriptionResponseDto>> GetAll();

        Task<LanguageResponseDto?> GetLanguage(int alarmEventDescriptionId);
    }
}
