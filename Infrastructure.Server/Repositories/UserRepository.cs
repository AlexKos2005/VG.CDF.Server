using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BreadCommunityWeb.Blz.Application.Interfaces.Repositories;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using BreadCommunityWeb.Blz.Domain.Entities;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlDataContext _sqlDataContext;

        public UserRepository(SqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }

        public async Task<User?> GetUserByEmailAndPassHashWithResult(string Email, string passHash)
        {
            var result = await _sqlDataContext.Users.Where(p => p.Email == Email && p.PasswordHash == passHash).FirstOrDefaultAsync();
            return result;

        }

        public async Task<User?> GetUserByIdWithResult(int userId)
        {
            var result = await _sqlDataContext.Users.Where(p => p.Id == userId).FirstOrDefaultAsync();
            return result;

        }

        public async Task<List<User>?> GetAllUsersWithResult()
        {
            var result = await _sqlDataContext.Users.ToListAsync();
            return result;

        }

        public async Task SetUserWithResult(User user)
        {
            user.Role = await _sqlDataContext.Roles.FirstOrDefaultAsync();
            await _sqlDataContext.Users.AddAsync(user);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task DeleteUserByIdWithResult(int userId)
        {
            var user = await _sqlDataContext.Users.Where(c => c.Id == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                return;
            }

            _sqlDataContext.Users.Remove(user);
            await _sqlDataContext.SaveChangesAsync();

        }

        public async Task UpdateUserByIdWithResult(int userId, User user)
        {
            var currentUser = await _sqlDataContext.Users.Where(c => c.Id == userId).FirstOrDefaultAsync();
            if (currentUser == null)
            {
                return;
            }

            currentUser.Email = user.Email;
            currentUser.UsersFactories = user.UsersFactories;
            currentUser.Folders = user.Folders;
            currentUser.PasswordHash = user.PasswordHash;
            currentUser.Role = user.Role;
            currentUser.RoleId = currentUser.RoleId;

            _sqlDataContext.Users.Update(currentUser);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task AddFactory(int userId, int factoryId)
        {
            var user = await _sqlDataContext.Users.Where(c => c.Id == userId).FirstOrDefaultAsync();
            var factory = await _sqlDataContext.Factories.Where(c => c.Id == factoryId).FirstOrDefaultAsync();
            var userFactory = new UserFactory() 
            {
                UserId = user.Id,
                User = user,
                FactoryId = factory.Id,
                Factory = factory
            };
            await _sqlDataContext.UsersFactories.AddAsync(userFactory);
            await _sqlDataContext.SaveChangesAsync();
        }
    }
}
