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
    public class TagParamService : ITagParamService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public TagParamService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }

        public async Task AddDescriptionByExternalId(int tagParamExternalId, TagParamDescriptionRequestDto tagDescription)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagRepository = new TagParamRepository(db);
            var tagParamDesc = _mapper.Map<ParameterDescription>(tagDescription);
            await tagRepository.AddDescriptionByExternalId(tagParamExternalId, tagParamDesc);
        }

        public async Task AddDescriptionById(int tagParamId, TagParamDescriptionRequestDto tagDescription)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagRepository = new TagParamRepository(db);
            var tagParamDesc = _mapper.Map<ParameterDescription>(tagDescription);
            tagParamDesc.ParameterId = tagParamId;
            await tagRepository.AddDescriptionById(tagParamId, tagParamDesc);
        }

        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagRepository = new TagParamRepository(db);
            await tagRepository.Delete(id);
        }

        public async Task<TagParamResponseDto?> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagRepository = new TagParamRepository(db);
            var result = await tagRepository.Get(id);
            if(result == null)
            {
                return null;
            }

            return _mapper.Map<TagParamResponseDto>(result);
        }

        public async Task<List<TagParamResponseDto>> GetAll()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagRepository = new TagParamRepository(db);
            var result = await tagRepository.GetAll();
            var sortedResult = result.OrderBy(c => c.ExternalId).ToList();
            return _mapper.Map<List<TagParamResponseDto>>(sortedResult);
        }

        public async Task<TagParamResponseDto?> GetByExternalId(int tagParamExternalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagRepository = new TagParamRepository(db);
            var result = await tagRepository.GetByExternalId(tagParamExternalId);
            if (result == null)
            {
                return null;
            }

            return _mapper.Map<TagParamResponseDto>(result);
        }

        public async Task<List<TagParamDescriptionResponseDto>> GetDescriptions(int tagId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagRepository = new TagParamRepository(db);
            var tagDescriptions = await tagRepository.GetDescriptions(tagId);

            return _mapper.Map<List<TagParamDescriptionResponseDto>>(tagDescriptions);
        }
        public async Task<List<TagParamDescriptionResponseDto>> GetDescriptionsByExtenalId(int externalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagRepository = new TagParamRepository(db);
            return _mapper.Map<List<TagParamDescriptionResponseDto>>(await tagRepository.GetDescriptionsByExtenalId(externalId));
        }

        public async Task Save(List<TagParamRequestDto> tags)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagRepository = new TagParamRepository(db);
            await tagRepository.Save(_mapper.Map<List<Parameter>>(tags));
        }

        public async Task Save(TagParamRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagRepository = new TagParamRepository(db);
            await tagRepository.Save(_mapper.Map<Parameter>(entity));
        }

        public async Task<TagParamResponseDto?> Update(int id, TagParamRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagRepository = new TagParamRepository(db);
            var result = await tagRepository.Update(id, _mapper.Map<Parameter>(entity));
            if (result == null)
            {
                return null;
            }

            return _mapper.Map<TagParamResponseDto>(result);
        }

      
    }
}
