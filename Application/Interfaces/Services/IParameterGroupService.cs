using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
{
   public interface IParameterGroupService : ICrudService<ParameterGroupRequestDto, ParameterGroupResponseDto,int>
    {
        Task<List<ParameterGroupResponseDto>> GetAll();
    }
}
