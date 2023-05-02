using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
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
