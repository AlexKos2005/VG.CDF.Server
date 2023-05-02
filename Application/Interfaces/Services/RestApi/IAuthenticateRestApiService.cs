using BreadCommunityWeb.Blz.Application.Dto.RequestDto.Authentication;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services.RestApi
{
    public interface IAuthenticateRestApiService
    {
        Task<AuthenticationResponseDto?> LogIn(UserAuthenticationRequestDto userRequestDto);

        Task Logout();
    }
}
