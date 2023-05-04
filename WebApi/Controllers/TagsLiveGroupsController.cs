using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VG.CDF.Server.WebApi.Controllers
{
    /// <summary>
    /// Реал-тайм теги
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class TagsLiveGroupsController : ControllerBase
    {
        private readonly ITagsLiveService _tagsLiveService;
        private readonly ITagsGroupService _tagsGroupService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TagsLiveGroupsController(ITagsLiveService tagsLiveService, ITagsGroupService tagsGroupService, IMapper mapper)
        {
            _tagsLiveService = tagsLiveService;
            _tagsGroupService = tagsGroupService;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Сохранить группы тегов
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(PostTagsLiveGroups))]
        public async Task<ActionResult> PostTagsLiveGroups(List<TagsGroupRequestDto> tagsLiveGroups)
        {
            await _tagsGroupService.SaveTagsGroups(tagsLiveGroups);
            _logger.Trace($"Was save {tagsLiveGroups.Count} tagsLiveGroups from Factory {tagsLiveGroups[0].FactoryExternalId} by Device {tagsLiveGroups[0].DeviceExternalId}");
            return Ok();
        }

        /// <summary>
        /// Получить кол-во хранящихся групп тегов и тегов
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetGroupsAndTagLive))]
        public async Task<ActionResult<TagsLiveGroupsCountersRequestDto>> GetGroupsAndTagLive()
        {
            var counters = new TagsLiveGroupsCountersRequestDto();
            counters.TagsGroupCounter = await _tagsGroupService.GetTagsGroupCount();
            counters.TagsLiveCounter = await _tagsLiveService.GetTagsLiveCount();

            var tt = await _tagsLiveService.Get(10101, 1, DateTime.Now);

            return Ok(counters);
        }

        /// <summary>
        /// Получить теги за период
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetTagsLive))]
        public async Task<ActionResult<List<TagLiveResponseDto>>> GetTagsLive(TagsGroupsGettingInfoRequestDto tagsGroupsGetting)
        {
            var result = await _tagsLiveService.Get(10102, 8, tagsGroupsGetting.StartDate,tagsGroupsGetting.EndDate);
            var result1 = new List<TagLiveResponseDto>();
            result1.Add(result.FirstOrDefault());
            return Ok(result);
        }

        /// <summary>
        /// Получить группированные теги за период
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetTagsGroups))]
        public async Task<ActionResult<List<TagsGroupResponseDto>>> GetTagsGroups(TagsGroupsGettingInfoRequestDto tagsGroupsGetting)
        {
            var result = await _tagsGroupService.GetTagsGroup(tagsGroupsGetting.FactoryExternalId, tagsGroupsGetting.DeviceExternalId, tagsGroupsGetting.StartDate, tagsGroupsGetting.EndDate);

            return Ok(result);
        }
    }
}
