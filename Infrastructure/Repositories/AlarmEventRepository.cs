using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Repositories
{
    public class AlarmEventRepository : IAlarmEventRepository
    {
        private readonly ISqlDataContext _sqlDataContext;
        public AlarmEventRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }

        public async Task AddDescriptionByExternalId(int alarmEventExternalId, AlarmEventDescription alarmEventDescription)
        {
            var alarmEvent = await _sqlDataContext.AlarmEvents.Where(c => c.ExternalId == alarmEventExternalId).FirstOrDefaultAsync();
            if (alarmEvent == null)
            {
                return;
            }

            alarmEvent.AlarmEventDescriptions.Add(alarmEventDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task AddDescriptionById(int alarmEventId, AlarmEventDescription alarmEventDescription)
        {
            var alarmEvent = await _sqlDataContext.AlarmEvents.Where(c => c.Id == alarmEventId).FirstOrDefaultAsync();
            if (alarmEvent == null)
            {
                return;
            }

            alarmEvent.AlarmEventDescriptions.Add(alarmEventDescription);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var alarmEvent = await _sqlDataContext.AlarmEvents.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (alarmEvent == null)
            {
                return;
            }

            _sqlDataContext.AlarmEvents.Remove(alarmEvent);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task DeleteDescription(int alarmEventId, int alarmEventDescriptionId)
        {
            var alarmEventDesc = await _sqlDataContext.AlarmEventDescriptions.Where(c => c.Id == alarmEventDescriptionId).FirstOrDefaultAsync();
             _sqlDataContext.AlarmEventDescriptions.Remove(alarmEventDesc);
            await _sqlDataContext.SaveChangesAsync();

        }

        public async Task<AlarmEvent> Get(int alarmEventId)
        {
            return await _sqlDataContext.AlarmEvents.Where(c => c.Id == alarmEventId).Include(c=>c.AlarmEventDescriptions).FirstOrDefaultAsync();
        }

        public async Task<List<AlarmEvent>> GetAll()
        {
            return await _sqlDataContext.AlarmEvents.Include(c => c.AlarmEventDescriptions).ToListAsync();
        }

        public async Task<AlarmEvent?> GetByExternalId(int alarmEventExternalId)
        {
            return await _sqlDataContext.AlarmEvents.Where(c => c.ExternalId == alarmEventExternalId).Include(c => c.AlarmEventDescriptions).FirstOrDefaultAsync();
        }

        public async Task<List<AlarmEventDescription>> GetDescriptions(int alarmEventId)
        {
            return await _sqlDataContext.AlarmEventDescriptions.Where(c => c.AlarmEventId == alarmEventId).Include(c => c.DescriptionsLanguage).ToListAsync();
            
        }

        public async Task<List<AlarmEventDescription>> GetDescriptionsByExtenalId(int externalId)
        {
            return await _sqlDataContext.AlarmEventDescriptions.Where(c => c.AlarmEvent.ExternalId == externalId).Include(c => c.DescriptionsLanguage).ToListAsync();
        }

        public async Task Save(AlarmEvent entity)
        {
            await _sqlDataContext.AlarmEvents.AddAsync(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Save(List<AlarmEvent> alarmEvents)
        {
            await _sqlDataContext.AlarmEvents.AddRangeAsync(alarmEvents);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<AlarmEvent?> Update(int id, AlarmEvent entity)
        {
            var alarmEvent = await _sqlDataContext.AlarmEvents.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (alarmEvent == null)
            {
                return null;
            }

            alarmEvent.ExternalId = entity.ExternalId;
            alarmEvent.Device = entity.Device;
            alarmEvent.DeviceId = entity.DeviceId;

            _sqlDataContext.AlarmEvents.Update(alarmEvent);
            await _sqlDataContext.SaveChangesAsync();

            return alarmEvent;
        }
    }
}
