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
    ///Описания устройств
    ///</summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class DeviceDescriptionController : ControllerBase
    {
        private readonly IDeviceDescriptionService _deviceDescriptionService;
        public DeviceDescriptionController(IDeviceDescriptionService deviceDescriptionService)
        {
            _deviceDescriptionService = deviceDescriptionService;
        }

        /// <summary>
        /// Получить все описания устройств
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllDeviceDescriptions))]
        public async Task<ActionResult<List<DeviceDescriptionResponseDto>>> GetAllDeviceDescriptions()
        {
            var result = await _deviceDescriptionService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Получить описание устройства
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetDeviceDescription))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeviceDescriptionResponseDto>> GetDeviceDescription(int id)
        {
            var result = await _deviceDescriptionService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Получить язык описания устройства
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetLanguageDeviceDescription))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeviceDescriptionResponseDto>> GetLanguageDeviceDescription(int deviceDescriptionId)
        {
            var result = await _deviceDescriptionService.GetLanguage(deviceDescriptionId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Сохранить описание устройства
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveDeviceDescription))]
        public async Task<ActionResult> SaveDeviceDescription(DeviceDescriptionRequestDto deviceDescriptionRequestDto)
        {
            await _deviceDescriptionService.Save(deviceDescriptionRequestDto);
            return Ok();

        }

        /// <summary>
        /// Удалить описание устройства
        /// </summary>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteDeviceDescription))]
        public async Task<ActionResult> DeleteDeviceDescription(int id)
        {
            await _deviceDescriptionService.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Обновить описание устройства
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(UpdateTagDescription))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeviceDescriptionResponseDto>> UpdateTagDescription(int id, DeviceDescriptionRequestDto deviceRequestDto)
        {
            var result = await _deviceDescriptionService.Update(id, deviceRequestDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
