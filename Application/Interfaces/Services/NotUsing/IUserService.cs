using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
{
   public interface IUserService
    {
        Task<UserResponseDto?> GetUserByEmailAndPass(string email, string passHash);
        Task<UserResponseDto> GetUserById(int userId);
        Task<List<UserResponseDto>> GetAllUsers();
        Task SaveUser(UserRequestDto user);
        Task DeleteUserById(int userId);

        Task UpdateUserById(int userId, UserRequestDto user);

        Task AddFactory(int userId, int factoryId);
    }
}
