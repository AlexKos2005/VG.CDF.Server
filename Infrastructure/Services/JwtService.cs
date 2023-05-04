using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using VG.CDF.Server.Application.Dto.ResponseDto.Authentication;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Infrastructure.Configurations;

namespace VG.CDF.Server.Infrastructure.Services
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
