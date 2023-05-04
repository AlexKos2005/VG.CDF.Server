using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;

namespace VG.CDF.Server.WebApi.Controllers
{
    ///<summary>
    ///Шаблоны отчетов
    ///</summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class ReportSchemaController : ControllerBase
    {
        private readonly IReportSchemaService _reportSchemaService;
        private readonly IMapper _mapper;
        public ReportSchemaController(IReportSchemaService reportSchemaService, IMapper mapper)
        {
            _reportSchemaService = reportSchemaService;
            _mapper = mapper;
        }


        /// <summary>
        /// Получить шаблон отчета
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetReportSchema))]
        public async Task<ActionResult<ReportSchemaResponseDto>> GetReportSchema(int id)
        {
            return Ok(await _reportSchemaService.Get(id));
        }

        /// <summary>
        /// Получить все шаблоны отчетов по всем устройствам по предприятию
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllReportSchemas))]
        public async Task<ActionResult<List<DevicesReportSchemasResponseDto>>> GetAllReportSchemas(int userId, int factoryId)
        {
            return Ok(await _reportSchemaService.GetAllReportSchemas(userId,factoryId));
        }

        /// <summary>
        /// Удалить шаблон отчета
        /// </summary>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteReportSchema))]
        public async Task<ActionResult> DeleteReportSchema(int id)
        {
            await _reportSchemaService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Сохранить шаблон отчета
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveReportSchema))]
        public async Task<ActionResult> SaveReportSchema(ReportSchemaRequestDto entity)
        {
            await _reportSchemaService.Save(entity);
            return Ok();
        }

        /// <summary>
        /// Обновить шаблон отчета
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(UpdateReportSchema))]
        public async Task<ActionResult<ReportSchemaResponseDto?>> UpdateReportSchema(int id,ReportSchemaRequestDto reportSchemaResponseDto)
        {
            return Ok(await _reportSchemaService.Update(id,reportSchemaResponseDto));
        }


        /// <summary>
        /// Обновить последовательность параметров в отчете
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(UpdateTagsParamQueue))]
        public async Task<ActionResult> UpdateTagsParamQueue(int id, List<TagParamReportRequestDto> tagParamReportRequestDtos)
        {
            if(await _reportSchemaService.UpdateTagReportQueues(id, tagParamReportRequestDtos))
            {
                return Ok();
            }
            else
            {
                return Conflict();
            }
        }
    }
}
