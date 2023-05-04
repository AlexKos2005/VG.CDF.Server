using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
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
