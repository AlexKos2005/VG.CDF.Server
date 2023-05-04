using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface ILanguageRepository : ICrud<DescriptionsLanguage,int>
    {
        Task<List<DescriptionsLanguage>> GetAll();

        Task<DescriptionsLanguage?> GetByExternalId(int languageExternalId);
        Task AddTagDescription(int languageId,TagParamDescription tagDescription);
        Task DeleteTagDescription(int languageId, int tagDescriptionId);

        Task AddDeviceDescription(int languageId, DeviceDescription deviceDescription);
        Task DeleteDeviceDescription(int languageId, int deviceDescriptionId);

        Task AddAlarmEventDescription(int languageId, AlarmEventDescription alarmEventDescription);
        Task DeleteAlarmEventDescription(int languageId, int alarmEventDescriptionId);
    }
}
