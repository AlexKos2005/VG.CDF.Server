using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto.Authentication;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Infrastructure.Server.Configurations;
using Microsoft.IdentityModel.Tokens;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Services
{
    public class JwtService : IJwtService<UserAuthenticationResponseDto>
    {
        private readonly JwtConfiguration _jwtConfiguration;
        public JwtService(JwtConfiguration jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration;
        }
        public string BuildToken(UserAuthenticationResponseDto entity)
        {
            var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtConfiguration.Key)); // NOTE: SAME KEY AS USED IN Startup.cs FILE
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            var claims = new[] // NOTE: could also use List<Claim> here
			{
                new Claim(ClaimTypes.Name, entity.Email), // NOTE: this will be the "User.Identity.Name" value
				new Claim(JwtRegisteredClaimNames.Sub, entity.Email),
                new Claim(JwtRegisteredClaimNames.Email, entity.Email),
                new Claim(JwtRegisteredClaimNames.Jti, entity.Id.ToString()) // NOTE: this could a unique ID assigned to the user by a database
			};

            var token = new JwtSecurityToken(issuer: _jwtConfiguration.Issuer, audience: _jwtConfiguration.Audience, claims: claims, expires: DateTime.Now.AddMinutes(_jwtConfiguration.ExpireTime), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
