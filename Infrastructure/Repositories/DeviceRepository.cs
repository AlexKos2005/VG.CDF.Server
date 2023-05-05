using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ISqlDataContext _sqlDataContext;

        public DeviceRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }

        public async Task AddDescriptionByExternalId(int deviceExternalId, ProcessDescription processDescription)
        {
            var device = await _sqlDataContext.Devices.Where(c => c.ExternalId == deviceExternalId).FirstOrDefaultAsync();
            if (device == null)
            {
                return;
            }

            device.DeviceDescriptions.Add(processDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task AddDescriptionById(int deviceId, ProcessDescription processDescription)
        {
            var device = await _sqlDataContext.Devices.Where(c => c.Id == deviceId).FirstOrDefaultAsync();
            if (device == null)
            {
                return;
            }

            device.DeviceDescriptions.Add(processDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task AddTagParam(int deviceId, Parameter parameter)
        {
            var device = await _sqlDataContext.Devices
                .Include(c=>c.TagsDevices)
                .Where(c => c.Id == deviceId).FirstOrDefaultAsync();
            if(device == null)
            {
                return;
            }

            //указанный параметр уже добавлен
            if(device.TagsDevices.Where(c => c.TagParamId == parameter.Id).FirstOrDefault() != null)
            {
                return;
            }

            var tagParamDevice = new ParameterProcess();
            tagParamDevice.ParameterId = parameter.Id;
            tagParamDevice.Parameter = parameter;
            tagParamDevice.ProcessId = device.Id;
            tagParamDevice.Process = device;
            device.TagsDevices.Add(tagParamDevice);

            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var deviceDescription = await _sqlDataContext.Devices.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (deviceDescription == null)
            {
                return;
            }

            _sqlDataContext.Devices.Remove(deviceDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task DeleteDescription(int deviceId, int deviceDescriptionId)
        {
            var deviceDesc = await _sqlDataContext.DeviceDescriptions.Where(c => c.Id == deviceDescriptionId).FirstOrDefaultAsync();
            _sqlDataContext.DeviceDescriptions.Remove(deviceDesc);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<Process> Get(int id)
        {
            return await _sqlDataContext.Devices.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Process>> GetAll()
        {
            return await _sqlDataContext.Devices.ToListAsync();
        }

        public async Task<List<Process>> GetAll(int factoryId)
        {
            return await _sqlDataContext.Devices.Where(c=>c.FactoryId == factoryId).Include(c=>c.DeviceDescriptions).Include(c=>c.TagsDevices).ThenInclude(c=>c.TagParam).ToListAsync();
        }

        public async Task<Process?> GetByExternalId(int deviceExternalId)
        {
            return await _sqlDataContext.Devices.Where(c => c.ExternalId == deviceExternalId).FirstOrDefaultAsync();
        }

        public async Task<List<ProcessDescription>> GetDescriptions(int deviceId)
        {
            return await _sqlDataContext.DeviceDescriptions.Where(c => c.DeviceId == deviceId).Include(c => c.DescriptionsLanguage).ToListAsync();
        }

        public async Task<List<ProcessDescription>> GetDescriptionsByExtenalId(int externalId)
        {
            var device = await _sqlDataContext.DeviceDescriptions.Where(c => c.Process.ExternalId == externalId).Include(c => c.DescriptionsLanguage).ToListAsync();
            return device;
        }

        public async Task<List<ParameterProcess>> GetTagParamsForDevice(int deviceId)
        {
            var tt =  await _sqlDataContext.TagParamsDevices.Where(c => c.ProcessId == deviceId).Include(c=>c.Parameter).ToListAsync();
            return tt;

        }

        public async Task Save(Process entity)
        {
            _sqlDataContext.Devices.Add(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Save(List<Process> devices)
        {
            _sqlDataContext.Devices.AddRange(devices);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<Process> Update(int id, Process entity)
        {
            var device = await _sqlDataContext.Devices.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (device == null)
            {
                return null;
            }

            device.DeviceCode = entity.DeviceCode;
            device.DeviceIp = entity.DeviceIp;

            _sqlDataContext.Devices.Update(device);
            await _sqlDataContext.SaveChangesAsync();

            return device;
        }
    }
}
