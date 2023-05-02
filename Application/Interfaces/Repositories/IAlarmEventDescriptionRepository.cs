using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
    public interface IAlarmEventDescriptionRepository : ICrud<AlarmEventDescription,int>
    {
        Task Save(List<AlarmEventDescription> tagDescriptions);
        Task<List<AlarmEventDescription>> GetAll();

        Task<DescriptionsLanguage?> GetLanguage(int tagDescriptionId);
    }
}
