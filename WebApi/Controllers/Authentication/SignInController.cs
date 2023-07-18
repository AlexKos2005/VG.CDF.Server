using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Dto.ResponseDto.Authentication;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Application.Users.Queries;
using VG.CDF.Server.Dto.RequestDto.Authentication;
using VG.CDF.Server.Infrastructure.Configurations;
using VG.CDF.Server.Infrastructure.Extentions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VG.CDF.Server.WebApi.Controllers.Authentication
{
    ///<summary>
    ///Авторизация
    ///</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IJwtService<UserAuthenticationResponseDto> _tokenService;
        public SignInController(JwtConfiguration jwtConfiguration, IJwtService<UserAuthenticationResponseDto> tokenService, IMediator mediator)
        {
            _jwtConfiguration = jwtConfiguration;
            _tokenService = tokenService;
            _mediator = mediator;
        }

        [HttpPost(nameof(Authenticate))]
        public async Task<ActionResult<AuthenticationResponseDto>> Authenticate([FromBody] UserAuthenticationRequestDto userAuthenticationRequestDto)
        {
            var user = await _mediator.Send(new GetUsersListQuery() { Email = userAuthenticationRequestDto.Email });
            
            if(user.Any() == false)
            {
                return BadRequest("Неверный логин или пароль!");
            }

            if (user.First().PasswordHash != userAuthenticationRequestDto.Password.GetHashCodeSHA256())
            {
                return BadRequest("Неверный логин или пароль!");
            }

            var userAuth = new UserAuthenticationResponseDto()
            {
                Id = user.First().Id,
                Email = user.First().Email
            };
            
            var token = _tokenService.BuildToken(userAuth);
            var authResponse = new AuthenticationResponseDto()
            {
                IsAuthSuccessful = true,
                JwtToken = token,
                Key = _jwtConfiguration.Key
            };

            return Ok(authResponse);
        }

    }
}
