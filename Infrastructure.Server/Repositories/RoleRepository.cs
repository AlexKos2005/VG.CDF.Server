using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BreadCommunityWeb.Blz.Application.Interfaces.Repositories;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Domain.Entities;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SqlDataContext _sqlDataContext;

        public RoleRepository(SqlDataContext sqlDataContext)
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
