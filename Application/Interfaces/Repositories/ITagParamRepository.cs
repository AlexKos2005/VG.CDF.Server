using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface ITagParamRepository : ICrud<TagParam,int>
    {
        Task<TagParam?> GetByExternalId(int tagParamExternalId);

        Task Save(List<TagParam> tags);
        Task<List<TagParam>> GetAll();

        Task AddDescriptionById(int tagParamId, TagParamDescription tagDescription);

        Task AddDescriptionByExternalId(int tagParamExternalId, TagParamDescription tagDescription);

        Task<List<TagParamDescription>> GetDescriptions(int tagId);

        Task<List<TagParamDescription>> GetDescriptionsByExtenalId(int externalId);
    }
}
