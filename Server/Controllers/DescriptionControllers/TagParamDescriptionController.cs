using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore;


namespace BreadCommunityWeb.Blz.Server.Controllers.DescriptionControllers
{
    ///<summary>
    ///Описания параметров тегов
    ///</summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class TagParamDescriptionController : ControllerBase
    {
        private readonly ITagParamDescriptionService _tagParamDescriptionService;
        public TagParamDescriptionController(ITagParamDescriptionService tagParamDescriptionService)
        {
            _tagParamDescriptionService = tagParamDescriptionService;
        }

        /// <summary>
        /// Получить все описания тегов
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllTagParamDescriptions))]
        public async Task<ActionResult<List<TagParamDescriptionResponseDto>>> GetAllTagParamDescriptions()
        {
            var result = await _tagParamDescriptionService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Получить описание тега
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetTagParamDescription))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TagParamDescriptionResponseDto>> GetTagParamDescription(int id)
        {
            var result = await _tagParamDescriptionService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Получить язык описания тега
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetLanguageTagParamDescription))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TagParamDescriptionResponseDto>> GetLanguageTagParamDescription(int tagDescriptionId)
        {
            var result = await _tagParamDescriptionService.GetLanguage(tagDescriptionId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Сохранить описание тега
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveTagParamDescription))]
        public async Task<ActionResult> SaveTagParamDescription(TagParamDescriptionRequestDto tagDescriptionRequestDto)
        {
            await _tagParamDescriptionService.Save(tagDescriptionRequestDto);
            return Ok();

        }

        /// <summary>
        /// Удалить описание тега
        /// </summary>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteTagParamDescription))]
        public async Task<ActionResult> DeleteTagParamDescription(int id)
        {
            await _tagParamDescriptionService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Обновить описание тега
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(UpdateTagParamDescription))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TagParamDescriptionResponseDto>> UpdateTagParamDescription(int id, TagParamDescriptionRequestDto languageRequestDto)
        {
            var result = await _tagParamDescriptionService.Update(id, languageRequestDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
