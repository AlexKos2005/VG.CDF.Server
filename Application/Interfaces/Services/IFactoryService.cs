using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
    public interface IFactoryService : ICrudService<FactoryRequestDto, FactoryResponseDto,int>
    {
        Task<List<FactoryResponseDto>> GetAllFactories();

        Task<FactoryResponseDto?> GetFactoryByExternalId(int factoryExternalId);
        Task<List<FactoryResponseDto>> GetAllFactories(int userId);
    }
}
