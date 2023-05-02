using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
    public interface IAlarmEventRepository : ICrud<AlarmEvent, int>
    {
        Task<AlarmEvent?> GetByExternalId(int alarmEventExternalId);
        Task Save(List<AlarmEvent> alarmEvents);

        Task<List<AlarmEvent>> GetAll();

        Task AddDescriptionById(int alarmEventId, AlarmEventDescription alarmEventDescription);
        Task AddDescriptionByExternalId(int alarmEventExternalId, AlarmEventDescription alarmEventDescription);

        Task DeleteDescription(int alarmEventId,int alarmEventDescriptionId);

        Task<List<AlarmEventDescription>> GetDescriptions(int alarmEventId);

        Task<List<AlarmEventDescription>> GetDescriptionsByExtenalId(int externalId);
    }
}
