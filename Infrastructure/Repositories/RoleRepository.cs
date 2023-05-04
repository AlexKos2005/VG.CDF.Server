
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ISqlDataContext _sqlDataContext;

        public RoleRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }


        public async Task<List<Role>> GetAllRoles()
        {
            return await _sqlDataContext.Roles.ToListAsync();
        }

        public async Task<Role?> Get(int id)
        {
            return await _sqlDataContext.Roles.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task Save(Role entity)
        {
            _sqlDataContext.Roles.Add(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var role = await _sqlDataContext.Roles.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (role == null)
            {
                return;
            }

            _sqlDataContext.Roles.Remove(role);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<Role?> Update(int id, Role entity)
        {
            var role = await _sqlDataContext.Roles.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (role == null)
            {
                return null;
            }

            role = entity;

            _sqlDataContext.Roles.Update(role);
            await _sqlDataContext.SaveChangesAsync();

            return role;
        }


    }
}
