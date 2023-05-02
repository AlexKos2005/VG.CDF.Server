using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
    public interface IRoleService : ICrudService<RoleRequestDto, RoleResponseDto,int>
    {
        Task<List<RoleResponseDto>> GetAllRolesWithResult();
    }
}
