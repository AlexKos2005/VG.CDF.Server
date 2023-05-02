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
    public class RoleService : IRoleService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public RoleService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }

        public async Task<List<RoleResponseDto>> GetAllRolesWithResult()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var roleRepository = new RoleRepository(db);
            var result = await roleRepository.GetAllRoles();
            return _mapper.Map<List<RoleResponseDto>>(result);
        }
        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var roleRepository = new RoleRepository(db);
            await roleRepository.Delete(id);
        }

        public async Task<RoleResponseDto> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var roleRepository = new RoleRepository(db);
            var result = await roleRepository.Get(id);
            return _mapper.Map<RoleResponseDto>(result);
        }

        public async Task Save(RoleRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var roleRepository = new RoleRepository(db);
            await roleRepository.Save(_mapper.Map<Role>(entity));
        }

        public async Task<RoleResponseDto> Update(int id, RoleRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var roleRepository = new RoleRepository(db);
            var result = await roleRepository.Update(id, _mapper.Map<Role>(entity));

            return _mapper.Map<RoleResponseDto>(result);
        }
    }
}
