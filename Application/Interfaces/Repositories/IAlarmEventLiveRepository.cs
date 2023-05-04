using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface IAlarmEventLiveRepository : ICrud<AlarmEventLive,long>
    {
        Task<List<AlarmEventLive>> GetAlarmEvents(int factoryExternalId, DateTime startDate, DateTime endDate);

        Task<List<AlarmEventLive>> GetAlarmEvents(int externalId, int factoryExternalId, DateTime startDate, DateTime endDate);

        Task<List<AlarmEventLive>> GetAlarmEventsByFactoryExternalIdAndDeviceExternalId(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate);
        Task Save(List<AlarmEventLive> alarmEventLives);
    }
}
