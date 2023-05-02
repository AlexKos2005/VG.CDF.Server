using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
    public interface IDeviceRepository : ICrud<Device,int>
    {
        Task<Device?> GetByExternalId(int deviceExternalId);
        Task Save(List<Device> devices);
        Task<List<Device>> GetAll();

        Task<List<Device>> GetAll(int factoryId);

        Task<List<TagParamDevice>> GetTagParamsForDevice(int deviceId);

        Task AddTagParam(int deviceId, TagParam tagParam);

        Task AddDescriptionById(int deviceId, DeviceDescription deviceDescription);

        Task AddDescriptionByExternalId(int deviceExternalId, DeviceDescription deviceDescription);

        Task DeleteDescription(int deviceId, int deviceDescriptionId);

        Task<List<DeviceDescription>> GetDescriptions(int deviceId);

        Task<List<DeviceDescription>> GetDescriptionsByExtenalId(int externalId);
    }
}
