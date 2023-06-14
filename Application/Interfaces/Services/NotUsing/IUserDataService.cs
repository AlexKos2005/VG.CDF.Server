using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.Client;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface IUserDataService
    {
        Task<List<DeviceWithDescriptionsDto>> GetDevicesByFactoryId(int factoryId);
        Task<List<TagParamWithDescriptions>> GetTagParamByDeviceId(int deviceId);

    }
}
