using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
   public interface IUserRepository
    {
        Task<User?> GetUserByEmailAndPassHashWithResult(string email,string passHash);
        Task<User?> GetUserByIdWithResult(int userId);
        Task<List<User>?> GetAllUsersWithResult();
        Task SetUserWithResult(User user);

        Task UpdateUserByIdWithResult(int userId, User user);
        Task DeleteUserByIdWithResult(int userId);

        Task AddFactory(int userId, int factoryId);
    }
}
