using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface ITagsLiveRepository : ICrud<ParameterValue,long>
    {
        Task<List<ParameterValue>> GetAllTagsLive();

        Task<List<ParameterValue>> Get(int factoryExternalId, int deviceExternalId, DateTime date);

        Task<List<ParameterValue>> Get(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate);
        Task<List<ParameterValue>> GetByTagsGroup(long tagsGroupId);

        Task Save(List<ParameterValue> tagsLives);
    }
}
