using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface ITagParamDescriptionRepository : ICrud<ParameterDescription,int>
    {
        Task Save(List<ParameterDescription> tagDescriptions);
        Task<List<ParameterDescription>> GetAll();

        Task<List<ParameterDescription>> GetAllByExternalId(int tagParamExternalId);

        Task<ParameterDescription?> Get(int tagParamId,int languageId);

        Task<Language?> GetLanguage(int tagDescriptionId);
    }
}
