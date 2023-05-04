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
    ///Устройства
    ///</summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;
        public DeviceController(IDeviceService deviceService, IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }


        /// <summary>
        /// Получить устройство по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetDevice))]
        public async Task<ActionResult<DeviceResponseDto>> GetDevice(int id)
        {

            var result = await _deviceService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Получить девайс по External ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetDeviceByExternalId))]
        public async Task<ActionResult<TagParamResponseDto>> GetDeviceByExternalId(int externalId)
        {
            var result = await _deviceService.GetByExternalId(externalId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Получить все устройства
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllDevices))]
        public async Task<ActionResult<List<DeviceResponseDto>>> GetAllDevices()
        {
            return Ok(await _deviceService.GetAll());
        }

        /// <summary>
        /// Получить описания устройства по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetDeviceDescriptionsById))]
        public async Task<ActionResult<List<DeviceDescriptionResponseDto>>> GetDeviceDescriptionsById(int id)
        {
            return Ok(await _deviceService.GetDescriptions(id));
        }

        /// <summary>
        /// Получить описания девайса по External ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetDeviceDescriptionsByExternalId))]
        public async Task<ActionResult<List<DeviceDescriptionResponseDto>>> GetDeviceDescriptionsByExternalId(int externalId)
        {
            return Ok(await _deviceService.GetDescriptionsByExtenalId(externalId));
        }

        /// <summary>
        /// Получить все параметры тегов, относящиеся к устройству по его External ID
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetTagParamsForDevice))]
        public async Task<ActionResult<List<TagParamResponseDto>>> GetTagParamsForDevice(int deviceExternalId)
        {
            var res = await _deviceService.GetTagParamsForDevice(deviceExternalId);

            return Ok(res);

        }

        /// <summary>
        /// Добавить описание устройству по ID
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(AddDeviceDescription))]
        public async Task<ActionResult> AddDeviceDescription(int deviceId, DeviceDescriptionRequestDto deviceDescription)
        {
            await _deviceService.AddDescriptionById(deviceId, deviceDescription);
            return Ok();

        }

        /// <summary>
        /// Добавить описание девайсу по External ID
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(AddDeviceDescriptionByExternalId))]
        public async Task<ActionResult> AddDeviceDescriptionByExternalId(int deviceExternalId, DeviceDescriptionRequestDto tagDescription)
        {
            await _deviceService.AddDescriptionByExternalId(deviceExternalId, tagDescription);
            return Ok();

        }

        /// <summary>
        /// Добавить описания нескольким девайсам по External ID
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(AddScopeDevicesDescriptionByExternalId))]
        public async Task<ActionResult> AddScopeDevicesDescriptionByExternalId(List<DeviceDescriptionsWithExternalIdRequestDto> deviceDescriptions)
        {
            foreach (var deviceDescription in deviceDescriptions)
            {
                await _deviceService.AddDescriptionByExternalId(deviceDescription.DeviceExternalId, deviceDescription.DeviceDescriptionRequestDto);
            }

            return Ok();

        }


        /// <summary>
        /// Сохранить одно устройство
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveDevice))]
        public async Task<ActionResult> SaveDevice(DeviceRequestDto device)
        {
            await _deviceService.Save(device);

            return Ok();
        }

        /// <summary>
        /// Сохранить несколько устройств
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveDevices))]
        public async Task<ActionResult> SaveDevices(List<DeviceRequestDto> devices)
        {
            await _deviceService.Save(devices);

            return Ok();
        }

        /// <summary>
        /// Добавить параметры тегов к устройству по его External ID
        /// Одно устройство может содержать множество тегов.
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(AddTagParamsToDevice))]
        public async Task<ActionResult> AddTagParamsToDevice(int deviceExternalId, List<int> tagparamsExternalId)
        {
            await _deviceService.AddTagParamsToDevice(deviceExternalId, tagparamsExternalId);

            return Ok();
        }



        /// <summary>
        /// Обновить устройство
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(UpdateDevice))]
        public async Task<ActionResult> UpdateDevice(int id, DeviceRequestDto device)
        {
            await _deviceService.Update(id, device);

            return Ok();
        }

        /// <summary>
        /// Удалить устройство по ID
        /// </summary>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteDevice))]
        public async Task<ActionResult> DeleteDevice(int id)
        {
            await _deviceService.Delete(id);
            return Ok();
        }


        /// <summary>
        /// Получить все устройства по External ID предприятия
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetByFactoryExternalId))]
        public async Task<ActionResult<List<DeviceResponseDto>>> GetByFactoryExternalId(int factoryExternalId)
        {
            return Ok(await _deviceService.GetAllByFactoryExternalId(factoryExternalId));
        }

        /// <summary>
        /// Получить все устройства по ID предприятия
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetByFactoryId))]
        public async Task<ActionResult<List<DeviceResponseDto>>> GetByFactoryId(int factoryId)
        {
            return Ok(await _deviceService.GetAllByFactoryId(factoryId));
        }
    }
}
