using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
    public interface ITagsLiveRepository : ICrud<TagLive,long>
    {
        Task<List<TagLive>> GetAllTagsLive();

        Task<List<TagLive>> Get(int factoryExternalId, int deviceExternalId, DateTime date);

        Task<List<TagLive>> Get(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate);
        Task<List<TagLive>> GetByTagsGroup(long tagsGroupId);

        Task Save(List<TagLive> tagsLives);
    }
}
