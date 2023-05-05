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
  
        public async Task AddUserFactoryWithResult(User user, Project project)
        {
           await _sqlDataContext.UsersFactories.AddAsync(new UserProject()
            {
                UserId = user.Id,
                ProjectId = project.Id,
            });
           await _sqlDataContext.SaveChangesAsync();

        }
    }
}
