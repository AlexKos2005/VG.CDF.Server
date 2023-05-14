using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface ILanguageRepository : ICrud<Language,int>
    {
        Task<List<Language>> GetAll();

        Task<Language?> GetByExternalId(int languageExternalId);
        Task AddTagDescription(int languageId,ParameterDescription tagDescription);
        Task DeleteTagDescription(int languageId, int tagDescriptionId);

        Task AddDeviceDescription(int languageId, ProcessDescription processDescription);
        Task DeleteDeviceDescription(int languageId, int deviceDescriptionId);

        Task AddAlarmEventDescription(int languageId, AlarmEventDescription alarmEventDescription);
        Task DeleteAlarmEventDescription(int languageId, int alarmEventDescriptionId);
    }
}
