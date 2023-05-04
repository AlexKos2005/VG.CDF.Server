using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface IParameterGroupRepository : ICrud<ParameterGroup,int>
    {
        Task<List<ParameterGroup>> GetAll();
    }
}
