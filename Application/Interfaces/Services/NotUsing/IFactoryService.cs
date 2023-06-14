using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface IFactoryService : ICrudService<FactoryRequestDto, FactoryResponseDto,int>
    {
        Task<List<FactoryResponseDto>> GetAllFactories();

        Task<FactoryResponseDto?> GetFactoryByExternalId(int factoryExternalId);
        Task<List<FactoryResponseDto>> GetAllFactories(int userId);
    }
}
