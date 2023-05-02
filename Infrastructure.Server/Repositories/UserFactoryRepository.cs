using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Application.Interfaces.Repositories;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Repositories
{
    public class UserFactoryRepository : IUserFactoryReposiroty
    {
        private readonly SqlDataContext _sqlDataContext;

        public UserFactoryRepository(SqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
  
        public async Task AddUserFactoryWithResult(User user, Factory factory)
        {
           await _sqlDataContext.UsersFactories.AddAsync(new UserFactory()
            {
                UserId = user.Id,
                FactoryId = factory.Id,
            });
           await _sqlDataContext.SaveChangesAsync();

        }
    }
}
