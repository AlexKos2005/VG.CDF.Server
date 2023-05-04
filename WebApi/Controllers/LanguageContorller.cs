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
    ///Языковые описания
    ///</summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        /// <summary>
        /// Получить все языки
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllLanguages))]
        public async Task<ActionResult<List<LanguageResponseDto>>> GetAllLanguages()
        {
            var result = await _languageService.GetAll();
            return Ok(result);
        }
        /// <summary>
        /// Получить язык
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetLanguage))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LanguageResponseDto>> GetLanguage(int id)
        {
            var result = await _languageService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        /// <summary>
        /// Сохранить язык
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveLanguage))]
        public async Task<ActionResult> SaveLanguage(DescriptionsLanguageRequestDto languageRequestDto)
        {
            await _languageService.Save(languageRequestDto);
            return Ok();
          
        }

        /// <summary>
        /// Удалить язык
        /// </summary>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteLanguage))]
        public async Task<ActionResult> DeleteLanguage(int id)
        {
            await _languageService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Обновить язык
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(UpdateLanguage))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LanguageResponseDto>> UpdateLanguage(int id, DescriptionsLanguageRequestDto languageRequestDto)
        {
            var result = await _languageService.Update(id, languageRequestDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //TODO: ParameterGroup: GetAll
    }
}
