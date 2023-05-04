using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Infrastructure.Configurations;
using VG.CDF.Server.Infrastructure.DataContext;
using VG.CDF.Server.Infrastructure.Repositories;


namespace VG.CDF.Server.Infrastructure.Services
{
    public class TagsGroupService : ITagsGroupService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public TagsGroupService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }
        public async Task Delete(long id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsGroupRepository = new TagsGroupRepository(db);
            await tagsGroupRepository.Delete(id);
        }

        public async Task<TagsGroupResponseDto> Get(long id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsGroupRepository = new TagsGroupRepository(db);
            var result = await tagsGroupRepository.Get(id);
            return _mapper.Map<TagsGroupResponseDto>(result);
        }

        public async Task<List<TagsGroupResponseDto>> GetAllTagsGroup()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsGroupRepository = new TagsGroupRepository(db);
            return _mapper.Map<List<TagsGroupResponseDto>>(await tagsGroupRepository.GetAllTagsGroup());
        }

        public async Task<List<TagsGroupResponseDto>> GetTagsGroup(int factoryExternalId, DateTime date)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsGroupRepository = new TagsGroupRepository(db);
            var result = await tagsGroupRepository.Get(factoryExternalId, date);
            return _mapper.Map<List<TagsGroupResponseDto>>(result);
        }

        public async Task<List<TagsGroupResponseDto>> GetTagsGroup(int factoryExternalId, int deviceExternalId, DateTime date)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsGroupRepository = new TagsGroupRepository(db);
            var result = await tagsGroupRepository.Get(factoryExternalId, deviceExternalId, date);
            return _mapper.Map<List<TagsGroupResponseDto>>(result);
        }

        public async Task<List<TagsGroupResponseDto>> GetTagsGroup(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsGroupRepository = new TagsGroupRepository(db);
            var result = await tagsGroupRepository.Get(factoryExternalId, deviceExternalId, startDate,endDate);
            return _mapper.Map<List<TagsGroupResponseDto>>(result);
        }

        public async Task<int> GetTagsGroupCount()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsGroupRepository = new TagsGroupRepository(db);
            var result = await tagsGroupRepository.GetAllTagsGroup();
            return result.Count();
        }

        public async Task Save(TagsGroupRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsGroupRepository = new TagsGroupRepository(db);
            await tagsGroupRepository.Save(_mapper.Map<TagsGroup>(entity));
        }

        public async Task SaveTagsGroups(List<TagsGroupRequestDto> tagsLiveGroups)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsGroupRepository = new TagsGroupRepository(db);
            var tagsGroupEntity = _mapper.Map<List<TagsGroup>>(tagsLiveGroups);
            await tagsGroupRepository.SaveGroups(_mapper.Map<List<TagsGroup>>(tagsGroupEntity));

        }

        public async Task SaveTagsLiveGroups(List<TagsLiveGroupRequestDto> tagsLiveGroups)
        {
            var tagsGroupList = new List<TagsGroup>();
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsGroupRepository = new TagsGroupRepository(db);
            foreach (var tagsGroup in tagsLiveGroups)
            {
                var tagsGroupEntity = _mapper.Map<TagsGroup>(tagsGroup.TagsGroup);
                var tagsLiveEntity = _mapper.Map<List<TagLive>>(tagsGroup.TagsLive);
                foreach (var tag in tagsLiveEntity)
                {
                    tagsGroupEntity.TagsLive.Add(tag);
                }
                
                tagsGroupList.Add(tagsGroupEntity);
            }

            await tagsGroupRepository.SaveGroups(_mapper.Map<List<TagsGroup>>(tagsGroupList));
        }

        public async Task<TagsGroupResponseDto> Update(long id, TagsGroupRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagsGroupRepository = new TagsGroupRepository(db);
            var result = await tagsGroupRepository.Update(id, _mapper.Map<TagsGroup>(entity));

            return _mapper.Map<TagsGroupResponseDto>(result);
        }
    }
}
