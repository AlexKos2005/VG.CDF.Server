
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Infrastructure.Repositories
{
    public class ParameterGroupRepository : IParameterGroupRepository
    {
        private readonly ISqlDataContext _sqlDataContext;
        public ParameterGroupRepository(ISqlDataContext sqlDataContext)
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
