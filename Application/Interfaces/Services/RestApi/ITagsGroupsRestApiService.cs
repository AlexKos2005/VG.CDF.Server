using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services.RestApi
{
    public interface ITagsGroupsRestApiService
    {
        Task<List<TagLiveResponseDto>> GetTagsLive(TagsGroupsGettingInfoRequestDto tagsGroupsGetting);

        Task<List<TagsGroupResponseDto>> GetTagsGroups(TagsGroupsGettingInfoRequestDto tagsGroupsGetting);
    }
}
