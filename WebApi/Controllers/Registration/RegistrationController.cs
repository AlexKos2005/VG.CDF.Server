using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.RequestDto.Registration;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Infrastructure.Extentions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VG.CDF.Server.WebApi.Controllers.Registration
{
    ///<summary>
    ///Регистрация
    ///</summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public RegistrationController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userRegistrationRequestDto"></param>
        /// <returns></returns>
        [HttpPost(nameof(Registrate))]
        public async Task<ActionResult> Registrate(UserRegistrationRequestDto userRegistrationRequestDto)
        {
            var user = new UserRequestDto();
            user.Email = userRegistrationRequestDto.Email;
            user.PasswordHash = userRegistrationRequestDto.Password.GetHashCodeSHA256();
            user.Role = new RoleRequestDto();

            await _userService.SaveUser(user);

            return Ok();
        }


    }
}
