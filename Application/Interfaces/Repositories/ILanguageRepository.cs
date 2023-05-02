using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
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
