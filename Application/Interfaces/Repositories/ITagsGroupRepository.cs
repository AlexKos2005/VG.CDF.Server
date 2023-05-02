using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
  public interface ITagsGroupRepository : ICrud<TagsGroup,long>
    {
        Task<List<TagsGroup>> GetAllTagsGroup();
        Task<List<TagsGroup>> Get(int factoryExternalId, DateTime date);

        Task<List<TagsGroup>> Get(int factoryExternalId, int deviceExternalId, DateTime date);

        Task<List<TagsGroup>> Get(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate);

        Task SaveGroups(List<TagsGroup> tagsGroups);
    }
}
