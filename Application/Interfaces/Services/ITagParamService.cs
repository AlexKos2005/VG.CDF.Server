using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
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
