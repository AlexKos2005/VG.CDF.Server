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
    public class AlarmEventDescriptionRepository : IAlarmEventDescriptionRepository
    {
        private readonly SqlDataContext _sqlDataContext;
        public AlarmEventDescriptionRepository(SqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
        public async Task Delete(int id)
        {
            var alarmEventDescriptions = await _sqlDataContext.AlarmEventDescriptions.Where(c => c.Id == id).FirstOrDefaultAsync();
            _sqlDataContext.AlarmEventDescriptions.Remove(alarmEventDescriptions);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<AlarmEventDescription?> Get(int id)
        {
            return await _sqlDataContext.AlarmEventDescriptions.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<AlarmEventDescription>> GetAll()
        {
            return await _sqlDataContext.AlarmEventDescriptions.ToListAsync();
        }

        public async Task<DescriptionsLanguage?> GetLanguage(int alarmEventDescriptionsId)
        {
            return await _sqlDataContext.AlarmEventDescriptions.Where(c => c.Id == alarmEventDescriptionsId).Select(s => s.DescriptionsLanguage).FirstOrDefaultAsync();
        }

        public async Task Save(List<AlarmEventDescription> alarmEventDescriptions)
        {
            await _sqlDataContext.AlarmEventDescriptions.AddRangeAsync(alarmEventDescriptions);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task Save(AlarmEventDescription entity)
        {
            await _sqlDataContext.AlarmEventDescriptions.AddAsync(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<AlarmEventDescription?> Update(int id, AlarmEventDescription entity)
        {
            var alarmEventDescription = await _sqlDataContext.AlarmEventDescriptions.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (alarmEventDescription == null)
            {
                return null;
            }

            alarmEventDescription.Description = entity.Description;

            _sqlDataContext.AlarmEventDescriptions.Update(alarmEventDescription);
            await _sqlDataContext.SaveChangesAsync();

            return alarmEventDescription;
        }
    }
}
