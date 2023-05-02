using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
    public interface IParameterGroupRepository : ICrud<ParameterGroup,int>
    {
        Task<List<ParameterGroup>> GetAll();
    }
}
