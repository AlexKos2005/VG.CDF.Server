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
    public class DeviceRepository : IDeviceRepository
    {
        private readonly SqlDataContext _sqlDataContext;

        public DeviceRepository(SqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }

        public async Task AddDescriptionByExternalId(int deviceExternalId, DeviceDescription deviceDescription)
        {
            var device = await _sqlDataContext.Devices.Where(c => c.ExternalId == deviceExternalId).FirstOrDefaultAsync();
            if (device == null)
            {
                return;
            }

            device.DeviceDescriptions.Add(deviceDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task AddDescriptionById(int deviceId, DeviceDescription deviceDescription)
        {
            var device = await _sqlDataContext.Devices.Where(c => c.Id == deviceId).FirstOrDefaultAsync();
            if (device == null)
            {
                return;
            }

            device.DeviceDescriptions.Add(deviceDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task AddTagParam(int deviceId, TagParam tagParam)
        {
            var device = await _sqlDataContext.Devices
                .Include(c=>c.TagsDevices)
                .Where(c => c.Id == deviceId).FirstOrDefaultAsync();
            if(device == null)
            {
                return;
            }

            //указанный параметр уже добавлен
            if(device.TagsDevices.Where(c => c.TagParamId == tagParam.Id).FirstOrDefault() != null)
            {
                return;
            }

            var tagParamDevice = new TagParamDevice();
            tagParamDevice.TagParamId = tagParam.Id;
            tagParamDevice.TagParam = tagParam;
            tagParamDevice.DeviceId = device.Id;
            tagParamDevice.Device = device;
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

        public async Task<Device> Get(int id)
        {
            return await _sqlDataContext.Devices.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Device>> GetAll()
        {
            return await _sqlDataContext.Devices.ToListAsync();
        }

        public async Task<List<Device>> GetAll(int factoryId)
        {
            return await _sqlDataContext.Devices.Where(c=>c.FactoryId == factoryId).Include(c=>c.DeviceDescriptions).Include(c=>c.TagsDevices).ThenInclude(c=>c.TagParam).ToListAsync();
        }

        public async Task<Device?> GetByExternalId(int deviceExternalId)
        {
            return await _sqlDataContext.Devices.Where(c => c.ExternalId == deviceExternalId).FirstOrDefaultAsync();
        }

        public async Task<List<DeviceDescription>> GetDescriptions(int deviceId)
        {
            return await _sqlDataContext.DeviceDescriptions.Where(c => c.DeviceId == deviceId).Include(c => c.DescriptionsLanguage).ToListAsync();
        }

        public async Task<List<DeviceDescription>> GetDescriptionsByExtenalId(int externalId)
        {
            var device = await _sqlDataContext.DeviceDescriptions.Where(c => c.Device.ExternalId == externalId).Include(c => c.DescriptionsLanguage).ToListAsync();
            return device;
        }

        public async Task<List<TagParamDevice>> GetTagParamsForDevice(int deviceId)
        {
            var tt =  await _sqlDataContext.TagParamsDevices.Where(c => c.DeviceId == deviceId).Include(c=>c.TagParam).ToListAsync();
            return tt;

        }

        public async Task Save(Device entity)
        {
            _sqlDataContext.Devices.Add(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Save(List<Device> devices)
        {
            _sqlDataContext.Devices.AddRange(devices);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<Device> Update(int id, Device entity)
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
