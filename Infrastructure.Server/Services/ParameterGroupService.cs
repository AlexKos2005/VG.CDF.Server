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
