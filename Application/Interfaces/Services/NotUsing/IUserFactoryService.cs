using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface IUserFactoryService
    {
        Task AddUserFactoryWithResult(UserRequestDto user, FactoryRequestDto factory);
    }
}
