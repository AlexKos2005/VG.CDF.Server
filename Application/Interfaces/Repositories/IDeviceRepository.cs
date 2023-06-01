using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface IDeviceRepository : ICrud<Process,int>
    {
        Task<Process?> GetByExternalId(int deviceExternalId);
        Task Save(List<Process> devices);
        Task<List<Process>> GetAll();

        Task<List<Process>> GetAll(int factoryId);

        Task<List<ParameterProcess>> GetTagParamsForDevice(int deviceId);

        Task AddTagParam(int deviceId, Parameter parameter);

        Task AddDescriptionById(int deviceId, ProcessDescription processDescription);

        Task AddDescriptionByExternalId(int deviceExternalId, ProcessDescription processDescription);

        Task DeleteDescription(int deviceId, int deviceDescriptionId);

        Task<List<ProcessDescription>> GetDescriptions(int deviceId);

        Task<List<ProcessDescription>> GetDescriptionsByExtenalId(int externalId);
    }
}
