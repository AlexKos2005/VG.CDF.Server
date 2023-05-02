using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
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
