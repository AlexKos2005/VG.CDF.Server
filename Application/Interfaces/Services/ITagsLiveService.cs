using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
    public interface ITagsLiveService : ICrudService<TagLiveRequestDto, TagLiveResponseDto,long>
    {
        Task<int> GetTagsLiveCount();

        Task<List<TagLiveResponseDto>> GetAllTagsLive();
        Task<List<TagLiveResponseDto>> GetByTagsGroup(long tagsGroupId);

        Task<List<TagLiveResponseDto>> Get(int factoryExternalId,int  deviceExternalId,DateTime date);

        Task<List<TagLiveResponseDto>> Get(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate);
        Task Save(List<TagLiveRequestDto> tagsLives);
    }
}
