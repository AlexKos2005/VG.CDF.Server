using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
  public interface IRoleRepository : ICrud<Role,int>
    {
        Task<List<Role>?> GetAllRoles();
    }
}
