using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
    public interface ITagsGroupService : ICrudService<TagsGroupRequestDto,TagsGroupResponseDto, long>
    {
        Task<int> GetTagsGroupCount();

        Task<List<TagsGroupResponseDto>> GetAllTagsGroup();
        Task<List<TagsGroupResponseDto>> GetTagsGroup(int factoryExternalId, DateTime date);

        Task<List<TagsGroupResponseDto>> GetTagsGroup(int factoryExternalId, int deviceExternalId, DateTime date);

        Task<List<TagsGroupResponseDto>> GetTagsGroup(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate);

        Task SaveTagsLiveGroups(List<TagsLiveGroupRequestDto> tagsLiveGroups);

        Task SaveTagsGroups(List<TagsGroupRequestDto> tagsLiveGroups);
    }
}
