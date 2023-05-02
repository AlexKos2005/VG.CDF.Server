using BreadCommunityWeb.Blz.Application.Interfaces.Repositories;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Repositories
{
    public class ParameterGroupRepository : IParameterGroupRepository
    {
        private readonly SqlDataContext _sqlDataContext;
        public ParameterGroupRepository(SqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
        public async Task Delete(int id)
        {
            var parameterGroup = await _sqlDataContext.ParameterGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (parameterGroup == null)
            {
                return;
            }

            _sqlDataContext.ParameterGroups.Remove(parameterGroup);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<ParameterGroup?> Get(int id)
        {
            return await _sqlDataContext.ParameterGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ParameterGroup>> GetAll()
        {
            return await _sqlDataContext.ParameterGroups.ToListAsync();
        }

        public async Task Save(ParameterGroup entity)
        {
            await _sqlDataContext.ParameterGroups.AddAsync(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<ParameterGroup?> Update(int id, ParameterGroup entity)
        {
            var parameterGroup = await _sqlDataContext.ParameterGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (parameterGroup == null)
            {
                return null;
            }

            parameterGroup.Name = entity.Name;
            parameterGroup.ParameterGroupExternalId = entity.ParameterGroupExternalId;
            _sqlDataContext.ParameterGroups.Update(parameterGroup);
            await _sqlDataContext.SaveChangesAsync();

            return parameterGroup;
        }
    }
}
