using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Infrastructure.Services;

public class ParameterValuesGroupService : ISaveable<ParameterValuesGroupDto>
{
    private readonly ISqlDataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    public ParameterValuesGroupService(ISqlDataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;

        _logger = LogManager.GetCurrentClassLogger();
    }
    public async Task<bool> Save(IEnumerable<ParameterValuesGroupDto> parameterValuesGroups)
    {
        var groups = _mapper.Map<IEnumerable<ParameterValuesGroup>>(parameterValuesGroups);

        if (groups.Any() == false)
        {
            _logger.Warn($"ParameterValuesGroups count in zero");
            return false;
        }

        await _dataContext.Set<ParameterValuesGroup>().AddRangeAsync(groups);


        await _dataContext.SaveChangesAsync(CancellationToken.None);
        return true;

    }
}