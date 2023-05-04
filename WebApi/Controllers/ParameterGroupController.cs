using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;

namespace VG.CDF.Server.WebApi.Controllers
{
    ///<summary>
    ///Группы параметров
    ///</summary>
    [Route("api/admin/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class ParameterGroupController : ControllerBase
    {
        private readonly IParameterGroupService _parameterGroupService;
        private readonly IMapper _mapper;
        public ParameterGroupController(IParameterGroupService parameterGroupService)
        {
            _parameterGroupService = parameterGroupService;
        }


        /// <summary>
        /// Получить группу параметров
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetParameterGroup))]
        public async Task<ActionResult<ParameterGroupResponseDto>> GetParameterGroup(int id)
        {
            var result = await _parameterGroupService.Get(id);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Получить все группы параметров
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllParameterGroup))]
        public async Task<ActionResult<List<ParameterGroupResponseDto>>> GetAllParameterGroup()
        {
            var result = await _parameterGroupService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Сохранить группу параметров
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveParameterGroup))]
        public async Task<ActionResult> SaveParameterGroup(ParameterGroupRequestDto entity)
        {
            await _parameterGroupService.Save(entity);

            return Ok();
        }

        /// <summary>
        /// Обновить группу параметров
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(UpdateParameterGroup))]
        public async Task<ActionResult> UpdateParameterGroup(int id, ParameterGroupRequestDto entity)
        {
            var result = await _parameterGroupService.Update(id, entity);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Удалить группу параметров
        /// </summary>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteParameterGroup))]
        public async Task<ActionResult> DeleteParameterGroup(int id)
        {
            await _parameterGroupService.Delete(id);
            return Ok();
        }
    }
}
