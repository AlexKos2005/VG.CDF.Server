using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface ITagParamService : ICrudService<TagParamRequestDto, TagParamResponseDto,int>
    {
        Task<TagParamResponseDto?> GetByExternalId(int tagParamExternalId);
        Task Save(List<TagParamRequestDto> tags);
        Task<List<TagParamResponseDto>> GetAll();

        Task AddDescriptionById(int tagId, TagParamDescriptionRequestDto tagDescription);

        Task AddDescriptionByExternalId(int tagParamExternalId, TagParamDescriptionRequestDto tagDescription);

        Task<List<TagParamDescriptionResponseDto>> GetDescriptions(int tagId);

        Task<List<TagParamDescriptionResponseDto>> GetDescriptionsByExtenalId(int externalId);
    }
}
