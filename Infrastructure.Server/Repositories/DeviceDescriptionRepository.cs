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
    public class DeviceDescriptionRepository : IDeviceDescriptionRepository
    {
        private readonly SqlDataContext _sqlDataContext;

        public DeviceDescriptionRepository(SqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
     
        public async Task Delete(int id)
        {
            var deviceDescription = await _sqlDataContext.DeviceDescriptions.Where(c => c.Id == id).FirstOrDefaultAsync();
            _sqlDataContext.DeviceDescriptions.Remove(deviceDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<DeviceDescription?> Get(int id)
        {
            return await _sqlDataContext.DeviceDescriptions.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<DeviceDescription>> GetAll()
        {
            return await _sqlDataContext.DeviceDescriptions.ToListAsync();
        }

        public async Task<List<DeviceDescription>> GetAllByExternalId(int deviceParamExternalId)
        {
            return await _sqlDataContext.DeviceDescriptions.Where(c => c.Device.ExternalId == deviceParamExternalId).ToListAsync();
        }

        public async Task<DescriptionsLanguage?> GetLanguage(int deviceDescriptionId)
        {
            return await _sqlDataContext.DeviceDescriptions.Where(c => c.Id == deviceDescriptionId).Select(s => s.DescriptionsLanguage).FirstOrDefaultAsync();
        }

        public async Task Save(List<DeviceDescription> deviceDescriptions)
        {
            await _sqlDataContext.DeviceDescriptions.AddRangeAsync(deviceDescriptions);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Save(DeviceDescription entity)
        {
            await _sqlDataContext.DeviceDescriptions.AddAsync(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<DeviceDescription?> Update(int id, DeviceDescription entity)
        {
            var deviceDescription = await _sqlDataContext.DeviceDescriptions.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (deviceDescription == null)
            {
                return null;
            }

            deviceDescription.Description = entity.Description;

            _sqlDataContext.DeviceDescriptions.Update(deviceDescription);
            await _sqlDataContext.SaveChangesAsync();

            return deviceDescription;
        }
    }
}
