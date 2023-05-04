using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VG.CDF.Server.WebApi.Controllers
{
    /// <summary>
    /// Пользовательская информация
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly IUserDataService _userDataService;
        private readonly IFactoryService _factoryService;
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;
        public UserDataController(IUserDataService userDataService, IFactoryService factoryService, IMapper mapper, IDeviceService deviceService)
        {
            _userDataService = userDataService;
            _factoryService = factoryService;
            _deviceService = deviceService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet(nameof(GetUserFactories))]
        public async Task<ActionResult<List<FactoryResponseDto>>> GetUserFactories(int userId)
        {
            var tt = await _factoryService.GetAllFactories(userId);
            return Ok(tt);
        }

        [Authorize]
        [HttpGet(nameof(GetDevicesByFactoryId))]
        public async Task<ActionResult<List<DeviceWithDescriptionsDto>>> GetDevicesByFactoryId(int factoryId)
        {
            var tt = await _userDataService.GetDevicesByFactoryId(factoryId);
            return Ok(tt);
        }

        [Authorize]
        [HttpGet(nameof(GetTagParamsByDeviceId))]
        public async Task<ActionResult<List<TagParamWithDescriptions>>> GetTagParamsByDeviceId(int deviceId)
        {
            var tt = await _userDataService.GetTagParamByDeviceId(deviceId);
            return Ok(tt);
        }
    }
}
