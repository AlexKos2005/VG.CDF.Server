using BreadCommunityWeb.Blz.Application.Interfaces.Repositories;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Repositories
{
    public class AlarmEventLiveRepository : IAlarmEventLiveRepository
    {
        private readonly SqlDataContext _sqlDataContext;

        public AlarmEventLiveRepository(SqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }

        public async Task Delete(long id)
        {
            var alarmEventLive = await _sqlDataContext.AlarmEventsLive.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (alarmEventLive == null)
            {
                return;
            }

            _sqlDataContext.AlarmEventsLive.Remove(alarmEventLive);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<AlarmEventLive> Get(long id)
        {
            return await _sqlDataContext.AlarmEventsLive.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<AlarmEventLive>> GetAlarmEvents(int factoryExternalId, DateTime startDate, DateTime endDate)
        {
            var tt = await _sqlDataContext.AlarmEventsLive.Where(c => c.FactoryExternalId == factoryExternalId && c.DateTime >= startDate && c.DateTime <= endDate).ToListAsync();
            return tt;
        }

        public async Task<List<AlarmEventLive>> GetAlarmEvents(int externalId, int factoryExternalId, DateTime startDate, DateTime endDate)
        {
            return await _sqlDataContext.AlarmEventsLive.Where(c => c.ExternalId == externalId && c.FactoryExternalId == factoryExternalId && c.DateTime >= startDate && c.DateTime <= endDate).ToListAsync();
        }

        public async Task<List<AlarmEventLive>> GetAlarmEventsByFactoryExternalIdAndDeviceExternalId(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate)
        {
            return await _sqlDataContext.AlarmEventsLive.Where(c => c.DeviceExternalId == deviceExternalId && c.FactoryExternalId == factoryExternalId && c.DateTime >= startDate && c.DateTime <= endDate).ToListAsync();
        }

        public async Task Save(List<AlarmEventLive> alarmEventLives)
        {
            await _sqlDataContext.AlarmEventsLive.AddRangeAsync(alarmEventLives);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Save(AlarmEventLive entity)
        {
            await _sqlDataContext.AlarmEventsLive.AddAsync(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<AlarmEventLive?> Update(long id, AlarmEventLive entity)
        {
            var alarmEvent = await _sqlDataContext.AlarmEventsLive.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (alarmEvent == null)
            {
                return null;
            }

            alarmEvent.DateTime = entity.DateTime;
            alarmEvent.DateTimeOffset = entity.DateTimeOffset;
            alarmEvent.DeviceExternalId = entity.DeviceExternalId;
            alarmEvent.ExternalId = entity.ExternalId;
            entity.FactoryExternalId = entity.FactoryExternalId;

            _sqlDataContext.AlarmEventsLive.Update(alarmEvent);
            await _sqlDataContext.SaveChangesAsync();

            return alarmEvent;
        }
    }
}
