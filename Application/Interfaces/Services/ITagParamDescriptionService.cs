using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
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
