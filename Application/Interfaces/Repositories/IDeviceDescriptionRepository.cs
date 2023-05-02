using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
    public interface IDeviceDescriptionRepository : ICrud<DeviceDescription,int>
    {
        Task Save(List<DeviceDescription> deviceDescriptions);
        Task<List<DeviceDescription>> GetAll();

        Task<List<DeviceDescription>> GetAllByExternalId(int deviceParamExternalId);
        Task<DescriptionsLanguage?> GetLanguage(int deviceDescriptionId);
    }
}
