using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface ITagParamRepository : ICrud<Parameter,int>
    {
        Task<Parameter?> GetByExternalId(int tagParamExternalId);

        Task Save(List<Parameter> tags);
        Task<List<Parameter>> GetAll();

        Task AddDescriptionById(int tagParamId, ParameterDescription tagDescription);

        Task AddDescriptionByExternalId(int tagParamExternalId, ParameterDescription tagDescription);

        Task<List<ParameterDescription>> GetDescriptions(int tagId);

        Task<List<ParameterDescription>> GetDescriptionsByExtenalId(int externalId);
    }
}
