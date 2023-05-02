using BreadCommunityWeb.Blz.Application.Dto.RequestDto.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services.RestApi
{
    public interface IRegisterRestApiService
    {
        Task Register(UserRegistrationRequestDto userRequestDto);
    }
}
