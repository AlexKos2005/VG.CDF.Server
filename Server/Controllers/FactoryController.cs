using AutoMapper;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Infrastructure.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BreadCommunityWeb.Blz.Server.Controllers
{
    ///<summary>
    ///Предприятия
    ///</summary>
    [Route("api/admin/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class FactoryController : ControllerBase
    {
        private readonly IFactoryService _factoryService;
        private readonly IMapper _mapper;
        public FactoryController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }
        
        /// <summary>
        /// Получить все предприятия
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllFactories))]
        public async Task<ActionResult<List<FactoryResponseDto>>> GetAllFactories()
        {
            return Ok(await _factoryService.GetAllFactories());
        }
        
        // <summary>
        /// Получить предприятие по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetFactoryById))]
        public async Task<ActionResult<FactoryResponseDto>> GetFactoryById(int id)
        {
            return Ok(await _factoryService.Get(id));
        }

        /// <summary>
        /// Получить предприятие по External ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetFactoryByExternalId))]
        public async Task<ActionResult<List<FactoryResponseDto>>> GetFactoryByExternalId(int factoryExternalId)
        {
            return Ok(await _factoryService.GetFactoryByExternalId(factoryExternalId));
        }

        /// <summary>
        /// Сохранить новое предприятие
        /// </summary>
        /// <param name="factoryDto"></param>
        /// <returns></returns>
        [HttpPost(nameof(PostFactory))]
        public async Task<ActionResult> PostFactory(FactoryRequestDto factoryDto)
        {
            await _factoryService.Save(factoryDto);
            return Ok();
        }

        /// <summary>
        /// Удалить предприятие
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteFactory))]
        public async Task<ActionResult> DeleteFactory(int id)
        {
            await _factoryService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Обновить предприятие
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateFactory))]
        public async Task<ActionResult> UpdateFactory(int id, FactoryRequestDto factoryDto)
        {
            await _factoryService.Update(id,factoryDto);
            return Ok();
        }
    }
}
