using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface IAlarmEventDescriptionService : ICrudService<AlarmEventDescriptionRequestDto, AlarmEventDescriptionResponseDto, int>
    {
        Task Save(List<AlarmEventDescriptionRequestDto> alarmEventDescriptions);
        Task<List<AlarmEventDescriptionResponseDto>> GetAll();

        Task<LanguageResponseDto?> GetLanguage(int alarmEventDescriptionId);
    }
}
