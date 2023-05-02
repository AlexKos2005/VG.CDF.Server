using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
   public interface IParameterGroupService : ICrudService<ParameterGroupRequestDto, ParameterGroupResponseDto,int>
    {
        Task<List<ParameterGroupResponseDto>> GetAll();
    }
}
