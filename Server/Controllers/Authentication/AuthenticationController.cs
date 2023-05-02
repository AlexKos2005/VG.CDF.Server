using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BreadCommunityWeb.Blz.Infrastructure.Server.Configurations;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto.Authentication;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto.Authentication;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreadCommunityWeb.Blz.Server.Controllers.Authentication
{
    ///<summary>
    ///Авторизация
    ///</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IJwtService<UserAuthenticationResponseDto> _tokenService;
        private readonly IUserService _userService;
        public AuthenticationController(JwtConfiguration jwtConfiguration, IJwtService<UserAuthenticationResponseDto> tokenService, IUserService userService)
        {
            _jwtConfiguration = jwtConfiguration;
            _tokenService = tokenService;
            _userService= userService;
        }

        [HttpPost(nameof(Authenticate))]
        public async Task<ActionResult<AuthenticationResponseDto>> Authenticate([FromBody] UserAuthenticationRequestDto userAuthenticationRequestDto)
        {
            var user = await _userService.GetUserByEmailAndPass(userAuthenticationRequestDto.Email, userAuthenticationRequestDto.Password);
            if(user == null)
            {
                return NoContent();
            }

            var userAuth = new UserAuthenticationResponseDto()
            {
                Id = user.Id,
                Email = user.Email
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
