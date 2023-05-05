using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
  public interface ITagsGroupRepository : ICrud<ParameterValuesGroup,long>
    {
        Task<List<ParameterValuesGroup>> GetAllTagsGroup();
        Task<List<ParameterValuesGroup>> Get(int factoryExternalId, DateTime date);

        Task<List<ParameterValuesGroup>> Get(int factoryExternalId, int deviceExternalId, DateTime date);

        Task<List<ParameterValuesGroup>> Get(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate);

        Task SaveGroups(List<ParameterValuesGroup> tagsGroups);
    }
}
