using AutoMapper;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Server.Controllers
{
    ///<summary>
    ///Аварийные события
    ///</summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class AlarmEventController : ControllerBase
    {
        private readonly IAlarmEventService _alarmEventService;
        private readonly IMapper _mapper;
        public AlarmEventController(IAlarmEventService alarmEventService, IMapper mapper)
        {
            _alarmEventService = alarmEventService;
            _mapper = mapper;
        }


        /// <summary>
        /// Получить параметр авар.события по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAlarmEvent))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AlarmEventLiveResponseDto>> GetAlarmEvent(int id)
        {
            var result = await _alarmEventService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Получить параметр тега по External ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAlarmEventByExternalId))]
        public async Task<ActionResult<AlarmEventResponseDto>> GetAlarmEventByExternalId(int externalId)
        {
            var result = await _alarmEventService.GetByExternalId(externalId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Получить все параметры всех авар.событий
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllAlarmEvents))]
        public async Task<ActionResult<List<AlarmEventResponseDto>>> GetAllAlarmEvents()
        {
            return Ok(await _alarmEventService.GetAll());
        }

        /// <summary>
        /// Получить описания параметра авар.события по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAlarmEventDescriptions))]
        public async Task<ActionResult<List<AlarmEventDescriptionResponseDto>>> GetAlarmEventDescriptions(int id)
        {
            return Ok(await _alarmEventService.GetDescriptions(id));
        }

        /// <summary>
        /// Получить описания параметра авар.события по External ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAlarmEventDescriptionsByExternalId))]
        public async Task<ActionResult<List<AlarmEventDescriptionResponseDto>>> GetAlarmEventDescriptionsByExternalId(int externalId)
        {
            return Ok(await _alarmEventService.GetDescriptionsByExtenalId(externalId));
        }

        /// <summary>
        /// Добавить описание авар.событию по ID
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(AddAlarmEventDescription))]
        public async Task<ActionResult> AddAlarmEventDescription(int alarmEventId, AlarmEventDescriptionRequestDto alarmEventDescription)
        {
            await _alarmEventService.AddDescriptionById(alarmEventId, alarmEventDescription);
            return Ok();

        }

        /// <summary>
        /// Добавить описание авар.событию по External ID
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(AddAlarmEventDescriptionByExternalId))]
        public async Task<ActionResult> AddAlarmEventDescriptionByExternalId(int alarmEventExternalId, AlarmEventDescriptionRequestDto alarmEventDescription)
        {
            await _alarmEventService.AddDescriptionByExternalId(alarmEventExternalId, alarmEventDescription);
            return Ok();

        }

        /// <summary>
        /// Добавить описания нескольким авар.событиям по External ID
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(AddScopeAlarmEventDescriptionByExternalId))]
        public async Task<ActionResult> AddScopeAlarmEventDescriptionByExternalId(List<AlarmEventDescriptionsWithExternalIdRequestDto> alarmEventDescriptions)
        {
            foreach (var alarmEventDescription in alarmEventDescriptions)
            {
                await _alarmEventService.AddDescriptionByExternalId(alarmEventDescription.AlarmEventExternalId, alarmEventDescription.AlarmEventDescriptionRequestDto);
            }

            return Ok();

        }

        /// <summary>
        /// Сохранить один параметр авар.события
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveAlarmEvent))]
        public async Task<ActionResult> SaveAlarmEvent(AlarmEventRequestDto alarmEvent)
        {
            await _alarmEventService.Save(alarmEvent);

            return Ok();
        }

        /// <summary>
        /// Сохранить несколько параметров авар.событий
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveAlarmEvents))]
        public async Task<ActionResult> SaveAlarmEvents(List<AlarmEventRequestDto> alarmEvents)
        {
            await _alarmEventService.Save(alarmEvents);

            return Ok();
        }

        /// <summary>
        /// Удалить авар.событие по ID
        /// </summary>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteAlarmEvent))]
        public async Task<ActionResult> DeleteAlarmEvent(int id)
        {
            await _alarmEventService.Delete(id);
            return Ok();
        }




        /// <summary>
        /// Обновить параметр авар.события
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(UpdateAlarmEvent))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAlarmEvent(int id, AlarmEventRequestDto alarmEvent)
        {
           var result = await _alarmEventService.Update(id, alarmEvent);
            if (result == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
