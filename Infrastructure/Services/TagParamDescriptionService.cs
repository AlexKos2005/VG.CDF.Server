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
    public class TagParamDescriptionService : ITagParamDescriptionService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public TagParamDescriptionService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagDescriptionRepository = new TagParamDescriptionRepository(db);
            await tagDescriptionRepository.Delete(id);
        }

        public async Task<TagParamDescriptionResponseDto?> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagDescriptionRepository = new TagParamDescriptionRepository(db);
            var result = await tagDescriptionRepository.Get(id);
            if (result == null)
            {
                return null;
            }

            return _mapper.Map<TagParamDescriptionResponseDto>(result);
        }

        public async Task<TagParamDescriptionResponseDto?> Get(int tagParamExternalId, int languageExternalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagDescriptionRepository = new TagParamDescriptionRepository(db);
            var languageRepository = new LanguageRepository(db);
            var languages = await languageRepository.GetAll();
            var language = languages.Where(c => c.ExternalId == languageExternalId).FirstOrDefault();
            if(language == null)
            {
                return null;
            }

            var descriptionsForTag = await tagDescriptionRepository.GetAllByExternalId(tagParamExternalId);
            if(descriptionsForTag.Any()==false)
            {
                return null;
            }

            var targetLandDescription = descriptionsForTag.Where(c => c.LanguageId == language.Id).FirstOrDefault();
            if (targetLandDescription == null)
            {
                return null;
            }


            return _mapper.Map<TagParamDescriptionResponseDto>(targetLandDescription);
        }

        public async Task<List<TagParamDescriptionResponseDto>> GetAll()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagDescriptionRepository = new TagParamDescriptionRepository(db);
            var result = await tagDescriptionRepository.GetAll();
            return _mapper.Map<List<TagParamDescriptionResponseDto>>(result);
        }

        public async Task<List<TagParamDescriptionResponseDto>> GetAllDescriptionsByDeviceExternalId(int tagParamExternalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagDescriptionRepository = new TagParamDescriptionRepository(db);
            var descriptionsForTag = await tagDescriptionRepository.GetAllByExternalId(tagParamExternalId);
            if (descriptionsForTag.Any() == false)
            {
                return new List<TagParamDescriptionResponseDto>();
            }

            return _mapper.Map<List<TagParamDescriptionResponseDto>>(descriptionsForTag);
        }

        public async Task<LanguageResponseDto?> GetLanguage(int tagDescriptionId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagDescriptionRepository = new TagParamDescriptionRepository(db);
            var result = await tagDescriptionRepository.GetLanguage(tagDescriptionId);
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<LanguageResponseDto>(result);
        }



        public async Task Save(TagParamDescriptionRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagDescriptionRepository = new TagParamDescriptionRepository(db);
            await tagDescriptionRepository.Save(_mapper.Map<ParameterDescription>(entity));
        }

        public async Task Save(List<TagParamDescriptionRequestDto> tagDescriptions)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagDescriptionRepository = new TagParamDescriptionRepository(db);
            await tagDescriptionRepository.Save(_mapper.Map<List<ParameterDescription>>(tagDescriptions));
        }

        public async Task<TagParamDescriptionResponseDto?> Update(int id, TagParamDescriptionRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var tagDescriptionRepository = new TagParamDescriptionRepository(db);
            var result = await tagDescriptionRepository.Update(id, _mapper.Map<ParameterDescription>(entity));
            if (result == null)
            {
                return null;
            }

            return _mapper.Map<TagParamDescriptionResponseDto>(result);
        }
    }
}
