using BreadCommunityWeb.Blz.Application.Dto.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
    public interface IUserDataService
    {
        Task<List<DeviceWithDescriptionsDto>> GetDevicesByFactoryId(int factoryId);
        Task<List<TagParamWithDescriptions>> GetTagParamByDeviceId(int deviceId);

    }
}
