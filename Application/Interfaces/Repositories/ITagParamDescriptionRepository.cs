using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface ITagParamDescriptionRepository : ICrud<TagParamDescription,int>
    {
        Task Save(List<TagParamDescription> tagDescriptions);
        Task<List<TagParamDescription>> GetAll();

        Task<List<TagParamDescription>> GetAllByExternalId(int tagParamExternalId);

        Task<TagParamDescription?> Get(int tagParamId,int languageId);

        Task<DescriptionsLanguage?> GetLanguage(int tagDescriptionId);
    }
}
