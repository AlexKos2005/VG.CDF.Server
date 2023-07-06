using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.WebApi.Controllers.ExternalService;

[Route("api/external/[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
public class AlarmEventController : Controller
{
    private ISaveable<AlarmEventLiveDto> _saveableService;
    public AlarmEventController(ISaveable<AlarmEventLiveDto> saveableService)
    {
        _saveableService = saveableService;
    }
    
    [HttpPost("SaveAlarmEvents")]
    public async Task<IActionResult> Create([FromBody] IEnumerable<AlarmEventLiveDto> alarmEvents)
    {
        await _saveableService.Save(alarmEvents);

        return Ok();
    }
}