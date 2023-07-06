using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Infrastructure.Services;

public class AlarmEventService : ISaveable<AlarmEventLiveDto>
{
    private readonly ISqlDataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    public AlarmEventService(ISqlDataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;

        _logger = LogManager.GetCurrentClassLogger();
    }
    public async Task<bool> Save(IEnumerable<AlarmEventLiveDto> parameterValuesGroups)
    {
        var alarmEvents = _mapper.Map<List<AlarmEventLive>>(parameterValuesGroups);

        if (alarmEvents.Any() == false)
        {
            _logger.Warn($"AlarmEvents count in zero");
            return false;
        }

        await _dataContext.Set<AlarmEventLive>().AddRangeAsync(alarmEvents);

        await _dataContext.SaveChangesAsync(CancellationToken.None);
        return true;

    }
    
}