using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface IAlarmEventDescriptionRepository : ICrud<AlarmEventDescription,int>
    {
        Task Save(List<AlarmEventDescription> tagDescriptions);
        Task<List<AlarmEventDescription>> GetAll();

        Task<DescriptionsLanguage?> GetLanguage(int tagDescriptionId);
    }
}
