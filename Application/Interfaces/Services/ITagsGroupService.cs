using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
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
