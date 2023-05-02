using BreadCommunityWeb.Blz.Application.Dto.Client;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services.RestApi
{
    public interface ITagsGroupsRestApiService
    {
        Task<List<TagLiveResponseDto>> GetTagsLive(TagsGroupsGettingInfoRequestDto tagsGroupsGetting);

        Task<List<TagsGroupResponseDto>> GetTagsGroups(TagsGroupsGettingInfoRequestDto tagsGroupsGetting);
    }
}
