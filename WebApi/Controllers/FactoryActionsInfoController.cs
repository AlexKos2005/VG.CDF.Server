using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;

namespace VG.CDF.Server.WebApi.Controllers
{
    ///<summary>
    ///События предприятий
    ///</summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class FactoryActionsInfoController : ControllerBase
    {
        private readonly IFactoryActionsInfoService _factoryActionsInfoService;
        private readonly ILogger _logger;
        public FactoryActionsInfoController(IFactoryActionsInfoService factoryActionsInfoService)
        {
            _factoryActionsInfoService = factoryActionsInfoService;
            _logger = LogManager.GetCurrentClassLogger();
        }


        /// <summary>
        /// Удалить таблицу событий предприятия
        /// </summary>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteFactoryActionsInfo))]
        public async Task<ActionResult> DeleteFactoryActionsInfo(int id)
        {
            await _factoryActionsInfoService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Получить таблицу событий предприятия
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetFactoryActionsInfo))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FactoryActionsInfoResponseDto>> GetFactoryActionsInfo(int id)
        {
            var result = await _factoryActionsInfoService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Получить таблицу событий предприятия по идентификатору предприятия
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetByFactoryExternalId))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FactoryActionsInfoResponseDto>> GetByFactoryExternalId(int factoryExternalId)
        {
            var result = await _factoryActionsInfoService.GetByFactoryExternalId(factoryExternalId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Сохранить таблицу событий предприятия
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveFactoryActionsInfo))]
        public async Task<ActionResult> SaveFactoryActionsInfo(FactoryActionsInfoRequestDto factoryActionsInfoRequestDto)
        {
            await _factoryActionsInfoService.Save(factoryActionsInfoRequestDto);
            return Ok();

        }

        /// <summary>
        /// Обновить таблицу событий предприятия
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(UpdateFactoryActionsInfo))]
        public async Task<ActionResult> UpdateFactoryActionsInfo(int id,FactoryActionsInfoRequestDto factoryActionsInfoRequestDto)
        {
            await _factoryActionsInfoService.Update(id,factoryActionsInfoRequestDto);
            return Ok();

        }

        /// <summary>
        /// Обновить время последнего подключения предприятия
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(ChangeLastDateTimeConnection))]
        public async Task<ActionResult> ChangeLastDateTimeConnection([FromBody] int factoryExternalId)
        {
            await _factoryActionsInfoService.ChangeLastDateTimeConnection(factoryExternalId, DateTime.Now, DateTime.UtcNow);
            return Ok();

        }

        /// <summary>
        /// Обновить время отправки отчета по определенному предприятию
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(ChangeLastDateTimeReportSending))]
        public async Task<ActionResult> ChangeLastDateTimeReportSending(FactoryReportingInfoRequestDto factoryReportingInfoRequestDto)
        {
            await _factoryActionsInfoService.ChangeLastDateTimeReportSending(factoryReportingInfoRequestDto.FactoryExternalId, factoryReportingInfoRequestDto.DateTime, factoryReportingInfoRequestDto.DateTimeOffset);
            _logger.Info($"Reporting time was changed for factory {factoryReportingInfoRequestDto.FactoryExternalId}");
            return Ok();

        }
    }
}
