using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto.Registration;

namespace VG.CDF.Server.Application.Interfaces.Services.RestApi
{
    public interface IRegisterRestApiService
    {
        Task Register(UserRegistrationRequestDto userRequestDto);
    }
}
