using AutoMapper;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Infrastructure.Server.Configurations;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using BreadCommunityWeb.Blz.Infrastructure.Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Services
{
    public class TagsLiveService : ITagsLiveService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public TagsLiveService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }

        public async Task Save(List<TagLiveRequestDto> tagsLives)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsLiveRepository = new TagsLiveRepository(db);
            await tagsLiveRepository.Save(_mapper.Map<List<TagLive>>(tagsLives));
        }

        public async Task<List<TagLiveResponseDto>> GetByTagsGroup(long tagsGroupId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsLiveRepository = new TagsLiveRepository(db);
            return _mapper.Map<List<TagLiveResponseDto>>(await tagsLiveRepository.GetByTagsGroup(tagsGroupId));
        }

        public async Task Delete(long id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsLiveRepository = new TagsLiveRepository(db);
            await tagsLiveRepository.Delete(id);
        }

        public async Task<TagLiveResponseDto> Get(long id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsLiveRepository = new TagsLiveRepository(db);
            var result = await tagsLiveRepository.Get(id);
            return _mapper.Map<TagLiveResponseDto>(result);
        }

        public async Task Save(TagLiveRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsLiveRepository = new TagsLiveRepository(db);
            await tagsLiveRepository.Save(_mapper.Map<TagLive>(entity));
        }

        public async Task<TagLiveResponseDto> Update(long id, TagLiveRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsLiveRepository = new TagsLiveRepository(db);
            var result = await tagsLiveRepository.Update(id, _mapper.Map<TagLive> (entity));

            return _mapper.Map<TagLiveResponseDto>(result);
        }

        public async Task<int> GetTagsLiveCount()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsLiveRepository = new TagsLiveRepository(db);
            var tags = await tagsLiveRepository.GetAllTagsLive();
            return tags.Count();
        }

        public async Task<List<TagLiveResponseDto>> GetAllTagsLive()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsLiveRepository = new TagsLiveRepository(db);
           return _mapper.Map<List<TagLiveResponseDto>>(await tagsLiveRepository.GetAllTagsLive());
        }
        public async Task<List<TagLiveResponseDto>> Get(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate)
        {
            var tags = new List<TagLive>();
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryRepository = new FactoryRepository(db);
            var deviceRepository = new DeviceRepository(db);
            var tagsLiveRepository = new TagsLiveRepository(db);

            var tagsLive = await tagsLiveRepository.Get(factoryExternalId, deviceExternalId, startDate, endDate);

            return _mapper.Map<List<TagLiveResponseDto>>(tagsLive);
            //return _mapper.Map<List<TagLiveResponseDto>>(tagsLive.OrderBy(c => c.TagsGroupId).ThenBy(s => s.TagParamExternalId).ToList());
        }


        public async Task<List<TagLiveResponseDto>> Get(int factoryExternalId, int deviceExternalId, DateTime date)
        {
            var tags = new List<TagLive>();
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryRepository = new FactoryRepository(db);
            var deviceRepository = new DeviceRepository(db);
            var tagsLiveRepository = new TagsLiveRepository(db);

            var tagsLive = await tagsLiveRepository.Get(factoryExternalId, deviceExternalId, date);

            return _mapper.Map<List<TagLiveResponseDto>>(tagsLive);
            //return _mapper.Map<List<TagLiveResponseDto>>(tagsLive.OrderBy(c => c.TagsGroupId).ThenBy(s=>s.TagParamExternalId).ToList());
        }

    }
}
