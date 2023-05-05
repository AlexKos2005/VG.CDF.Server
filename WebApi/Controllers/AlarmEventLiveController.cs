using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;

namespace VG.CDF.Server.WebApi.Controllers
{
    ///<summary>
    ///Реал-тайм аварийные события
    ///</summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class AlarmEventLiveController : ControllerBase
    {
        private readonly IAlarmEventLiveService _alarmEventLiveService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public AlarmEventLiveController(IAlarmEventLiveService alarmEventLiveService, IMapper mapper)
        {
            _alarmEventLiveService = alarmEventLiveService;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Сохранить аварийные реал-тайм события
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveAlarmEventsLive))]
        public async Task<ActionResult> SaveAlarmEventsLive(List<AlarmEventLiveRequestDto> alarmEventsLive)
        {
            await _alarmEventLiveService.Save(alarmEventsLive);
            _logger.Trace($"Was save {alarmEventsLive.Count} alarmEventsLive from {alarmEventsLive[0].FactoryExternalId} Project");
            return Ok();

        }

        /// <summary>
        /// Получить все аварийные реал-тайм события по предприятию за период
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetAlarmEventsLive))]
        public async Task<ActionResult<List<AlarmEventLiveResponseDto>>> GetAlarmEventsLive(int factoryExternalId, DateTime startDate, DateTime endDate)
        {
            var result = await _alarmEventLiveService.GetAlarmEventsLive(factoryExternalId, startDate, endDate);

            return Ok(result);

        }

        /// <summary>
        /// Получить аварийное реал-тайм событие по своему индентификатору и предприятию за период
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetAlarmEventsLiveForExternalId))]
        public async Task<ActionResult<List<AlarmEventLiveResponseDto>>> GetAlarmEventsLiveForExternalId(int externalId, int factoryExternalId, DateTime startDate, DateTime endDate)
        {
            var result = await _alarmEventLiveService.GetAlarmEventsLive(externalId,factoryExternalId, startDate, endDate);

            return Ok(result);
        }


    }
}
