using System.Collections.Generic;
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
    public class ParameterGroupService : IParameterGroupService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public ParameterGroupService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var parameterGroupRepository = new ParameterGroupRepository(db);
            await parameterGroupRepository.Delete(id);
        }

        public async Task<ParameterGroupResponseDto?> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var parameterGroupRepository = new ParameterGroupRepository(db);
            var result = await parameterGroupRepository.Get(id);
            if(result == null)
            {
                return null;
            }
            return _mapper.Map<ParameterGroupResponseDto>(result);
        }

        public async Task<List<ParameterGroupResponseDto>> GetAll()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var parameterGroupRepository = new ParameterGroupRepository(db);
            var result = await parameterGroupRepository.GetAll();

            return _mapper.Map<List<ParameterGroupResponseDto>>(result);
        }

        public async Task Save(ParameterGroupRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var parameterGroupRepository = new ParameterGroupRepository(db);
            await parameterGroupRepository.Save(_mapper.Map<ParameterGroup>(entity));
        }

        public async Task<ParameterGroupResponseDto?> Update(int id, ParameterGroupRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var parameterGroupRepository = new ParameterGroupRepository(db);
            var result = await parameterGroupRepository.Update(id, _mapper.Map<ParameterGroup>(entity));
            if (result == null)
            {
                return null;
            }

            return _mapper.Map<ParameterGroupResponseDto>(result);
        }
    }
}
