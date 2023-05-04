using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.ResponseDto.Authentication;
using VG.CDF.Server.Dto.RequestDto.Authentication;

namespace VG.CDF.Server.Application.Interfaces.Services.RestApi
{
    public interface IAuthenticateRestApiService
    {
        Task<AuthenticationResponseDto?> LogIn(UserAuthenticationRequestDto userRequestDto);

        Task Logout();
    }
}
