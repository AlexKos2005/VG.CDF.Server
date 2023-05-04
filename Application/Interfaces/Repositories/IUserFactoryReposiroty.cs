using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
   public interface IUserFactoryReposiroty
    {
        Task AddUserFactoryWithResult(User user, Factory factory);
    }
}
