using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Extentions;
using BreadCommunityWeb.Blz.Application.Interfaces.Repositories;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Domain.Enums;
using BreadCommunityWeb.Blz.Infrastructure.Server.Configurations;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using BreadCommunityWeb.Blz.Infrastructure.Server.Repositories;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Services
{
    public class UserService : IUserService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public UserService(DbConnectionConfig dbConnectionConfig,IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }

        public async Task AddFactory(int userId, int factoryId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var userRepository = new UserRepository(db);
            await userRepository.AddFactory(userId, factoryId);
        }

        public async Task DeleteUserById(int userId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var userRepository = new UserRepository(db);
            await userRepository.DeleteUserByIdWithResult(userId);
        }

        public async Task<List<UserResponseDto>> GetAllUsers()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var userRepository = new UserRepository(db);
            var res = await userRepository.GetAllUsersWithResult();
            return _mapper.Map<List<UserResponseDto>>(await userRepository.GetAllUsersWithResult());
        }

        public async Task<UserResponseDto?> GetUserByEmailAndPass(string email, string password)
        {
            var passHash = password.GetHashCodeSHA256();

            using var db = new SqlDataContext(_dbConnectionConfig);
            var userRepository = new UserRepository(db);
            return _mapper.Map<UserResponseDto>(await userRepository.GetUserByEmailAndPassHashWithResult(email, passHash));
        }

        public async Task<UserResponseDto> GetUserById(int userId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var userRepository = new UserRepository(db);
            return _mapper.Map<UserResponseDto>(await userRepository.GetUserByIdWithResult(userId));
        }

        public async Task SaveUser(UserRequestDto userDto)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var roleRepository = new RoleRepository(db);
            var roles = await roleRepository.GetAllRoles();
            if(roles.Any() == false)
            {
                await roleRepository.Save(new Role()
                {
                    RoleCode = RoleCodes.None,
                    RoleName = RoleCodes.None.ToString()
                });

            }
            var userRepository = new UserRepository(db);
            await userRepository.SetUserWithResult(_mapper.Map<User>(userDto));
        }

        public async Task UpdateUserById(int userId, UserRequestDto user)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var userRepository = new UserRepository(db);
            await userRepository.UpdateUserByIdWithResult(userId, _mapper.Map<User>(user));

        }
    }
}
