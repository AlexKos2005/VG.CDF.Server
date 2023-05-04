using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface IRoleService : ICrudService<RoleRequestDto, RoleResponseDto,int>
    {
        Task<List<RoleResponseDto>> GetAllRolesWithResult();
    }
}
