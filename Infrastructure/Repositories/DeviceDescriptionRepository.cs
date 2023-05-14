using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;


namespace BreadCommunityWeb.Blz.Infrastructure.Server.Repositories
{
    public class DeviceDescriptionRepository : IDeviceDescriptionRepository
    {
        private readonly ISqlDataContext _sqlDataContext;

        public DeviceDescriptionRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
     
        public async Task Delete(int id)
        {
            var deviceDescription = await _sqlDataContext.DeviceDescriptions.Where(c => c.Id == id).FirstOrDefaultAsync();
            _sqlDataContext.DeviceDescriptions.Remove(deviceDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<ProcessDescription?> Get(int id)
        {
            return await _sqlDataContext.DeviceDescriptions.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProcessDescription>> GetAll()
        {
            return await _sqlDataContext.DeviceDescriptions.ToListAsync();
        }

        public async Task<List<ProcessDescription>> GetAllByExternalId(int deviceParamExternalId)
        {
            return await _sqlDataContext.DeviceDescriptions.Where(c => c.Process.ExternalId == deviceParamExternalId).ToListAsync();
        }

        public async Task<Language?> GetLanguage(int deviceDescriptionId)
        {
            return await _sqlDataContext.DeviceDescriptions.Where(c => c.Id == deviceDescriptionId).Select(s => s.DescriptionsLanguage).FirstOrDefaultAsync();
        }

        public async Task Save(List<ProcessDescription> deviceDescriptions)
        {
            await _sqlDataContext.DeviceDescriptions.AddRangeAsync(deviceDescriptions);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Save(ProcessDescription entity)
        {
            await _sqlDataContext.DeviceDescriptions.AddAsync(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<ProcessDescription?> Update(int id, ProcessDescription entity)
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
