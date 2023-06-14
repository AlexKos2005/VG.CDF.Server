using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface ITagParamDescriptionService : ICrudService<TagParamDescriptionRequestDto, TagParamDescriptionResponseDto, int>
    {
        Task Save(List<TagParamDescriptionRequestDto> tagDescriptions);
        Task<List<TagParamDescriptionResponseDto>> GetAll();

        Task<List<TagParamDescriptionResponseDto>> GetAllDescriptionsByDeviceExternalId(int tagParamExternalId);
        Task<TagParamDescriptionResponseDto?> Get(int tagParamExternalId, int languageExternalId);
        Task<LanguageResponseDto?> GetLanguage(int tagDescriptionId);
    }
}
