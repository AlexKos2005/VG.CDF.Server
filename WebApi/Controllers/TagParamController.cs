using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;

namespace VG.CDF.Server.WebApi.Controllers
{
    ///<summary>
    ///Параметры тегов
    ///</summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    
    public class TagParamController : ControllerBase
    {
        private readonly ITagParamService _tagParamService;
        private readonly IUserDataService _userDataService;
        private readonly ITagParamDescriptionService _tagDescParamService;
        private readonly IMapper _mapper;
        public TagParamController(ITagParamService tagParamService, ITagParamDescriptionService tagDescParamService, IMapper mapper, IUserDataService userDataService)
        {
            _tagParamService = tagParamService;
            _tagDescParamService = tagDescParamService;
            _mapper = mapper;
            _userDataService = userDataService;
        }

        /// <summary>
        /// Получить параметр тега по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetTagParam))]
        public async Task<ActionResult<TagParamResponseDto>> GetTagParam(int id)
        {
 
            var result = await _tagParamService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [HttpGet(nameof(GetTagParamsByDeviceId))]
        public async Task<ActionResult<List<TagParamWithDescriptions>>> GetTagParamsByDeviceId(int deviceId)
        {
            var tt = await _userDataService.GetTagParamByDeviceId(deviceId);
            return Ok(tt);
        }

        /// <summary>
        /// Получить параметр тега по External ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetTagParamByExternalId))]
        public async Task<ActionResult<TagParamResponseDto>> GetTagParamByExternalId(int externalId)
        {
        
            var result = await _tagParamService.GetByExternalId(externalId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Получить все параметры всех тегов
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllTagsParam))]
        public async Task<ActionResult<List<TagParamResponseDto>>> GetAllTagsParam()
        {
            return Ok(await _tagParamService.GetAll());
        }

        /// <summary>
        /// Получить описания параметра тега по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetTagParamDescriptions))]
        public async Task<ActionResult<List<TagParamDescriptionResponseDto>>> GetTagParamDescriptions(int id)
        {
            return Ok(await _tagParamService.Get(id));
        }

        /// <summary>
        /// Получить описания параметра тега по External ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetTagParamDescriptionsByExternalId))]
        public async Task<ActionResult<List<TagParamDescriptionResponseDto>>> GetTagParamDescriptionsByExternalId(int externalId)
        {
            return Ok(await _tagParamService.GetDescriptionsByExtenalId(externalId));
        }


        /// <summary>
        /// Добавить описание параметру тега по ID
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(AddTagParamDescriptionById))]
        public async Task<ActionResult> AddTagParamDescriptionById(int tagParamId, TagParamDescriptionRequestDto tagDescription)
        {
            await _tagParamService.AddDescriptionById(tagParamId, tagDescription);
            return Ok();

        }

        /// <summary>
        /// Добавить описание параметру тега по External ID
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(AddTagParamDescriptionByExternalId))]
        public async Task<ActionResult> AddTagParamDescriptionByExternalId(int tagParamExternalId, TagParamDescriptionRequestDto tagDescription)
        {
            await _tagParamService.AddDescriptionByExternalId(tagParamExternalId, tagDescription);
            return Ok();

        }

        /// <summary>
        /// Добавить описания нескольким параметрам тегов по External ID
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(AddScopeTagParamDescriptionByExternalId))]
        public async Task<ActionResult> AddScopeTagParamDescriptionByExternalId(List<TagParamDescriptionsWithExternalIdRequestDto> tagDescriptions)
        {
            foreach (var tagDescription in tagDescriptions)
            {
                await _tagParamService.AddDescriptionByExternalId(tagDescription.TagParamExternalId, tagDescription.TagParamDescriptionRequestDto);
            }
           
            return Ok();

        }

        /// <summary>
        /// Сохранить один параметр
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveTagParam))]
        public async Task<ActionResult> SaveTagParam(TagParamRequestDto tagParam)
        {

            await _tagParamService.Save(tagParam);

            return Ok();
        }


        /// <summary>
        /// Сохранить несколько параметров
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveTagParams))]
        public async Task<ActionResult> SaveTagParams(List<TagParamRequestDto> tagsParams)
        {
            await _tagParamService.Save(tagsParams);

            return Ok();
        }

        /// <summary>
        /// Обновить параметр тега
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(UpdateTagParam))]
        public async Task<ActionResult> UpdateTagParam(int id, TagParamRequestDto tagParam)
        {
            await _tagParamService.Update(id,tagParam);

            return Ok();
        }

        /// <summary>
        /// Удалить параметр тега по ID
        /// </summary>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteTagParam))]
        public async Task<ActionResult> DeleteTagParam(int id)
        {
            await _tagParamService.Delete(id);
            return Ok();
        }

    }
}
