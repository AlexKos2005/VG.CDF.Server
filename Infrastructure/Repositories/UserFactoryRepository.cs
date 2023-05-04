using System.Threading.Tasks;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Infrastructure.Repositories
{
    public class UserFactoryRepository : IUserFactoryReposiroty
    {
        private readonly ISqlDataContext _sqlDataContext;

        public UserFactoryRepository(ISqlDataContext sqlDataContext)
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
