using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface IDeviceDescriptionRepository : ICrud<ProcessDescription,int>
    {
        Task Save(List<ProcessDescription> deviceDescriptions);
        Task<List<ProcessDescription>> GetAll();

        Task<List<ProcessDescription>> GetAllByExternalId(int deviceParamExternalId);
        Task<Language?> GetLanguage(int deviceDescriptionId);
    }
}
