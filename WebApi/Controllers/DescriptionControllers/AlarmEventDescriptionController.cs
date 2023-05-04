using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;

namespace VG.CDF.Server.WebApi.Controllers.DescriptionControllers
{
    ///<summary>
    ///Описания аварийных событий
    ///</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmEventDescriptionController : ControllerBase
    {
        private readonly IAlarmEventDescriptionService _alarmEventDescriptionService;
        public AlarmEventDescriptionController(IAlarmEventDescriptionService alarmEventDescriptionService)
        {
            _alarmEventDescriptionService = alarmEventDescriptionService;
        }

        /// <summary>
        /// Получить все описания аварийных событий
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllAlarmEventDescriptions))]
        public async Task<ActionResult<List<AlarmEventDescriptionResponseDto>>> GetAllAlarmEventDescriptions()
        {
            var result = await _alarmEventDescriptionService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Получить описание аварийного события
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAlarmEventDescription))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AlarmEventDescriptionResponseDto>> GetAlarmEventDescription(int id)
        {
            var result = await _alarmEventDescriptionService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Получить язык описания аварийного события
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetLanguageAlarmEventDescription))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AlarmEventDescriptionResponseDto>> GetLanguageAlarmEventDescription(int alarmEventDescriptionId)
        {
            var result = await _alarmEventDescriptionService.GetLanguage(alarmEventDescriptionId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Сохранить описание аварийного события
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveAlarmEventDescription))]
        public async Task<ActionResult> SaveAlarmEventDescription(AlarmEventDescriptionRequestDto tagDescriptionRequestDto)
        {
            await _alarmEventDescriptionService.Save(tagDescriptionRequestDto);
            return Ok();

        }

        /// <summary>
        /// Удалить описание аварийного события
        /// </summary>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteAlarmEventDescription))]
        public async Task<ActionResult> DeleteAlarmEventDescription(int id)
        {
            await _alarmEventDescriptionService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Обновить описание аварийного события
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(UpdateAlarmEventDescription))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TagParamDescriptionResponseDto>> UpdateAlarmEventDescription(int id, AlarmEventDescriptionRequestDto languageRequestDto)
        {
            var result = await _alarmEventDescriptionService.Update(id, languageRequestDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
