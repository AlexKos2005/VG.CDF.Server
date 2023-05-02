using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
   public interface IDoseWaRepository
    {
        Task<List<DoseWa>?> GetDosesWaByEnterpriseUIdAndDatesWithResult(int factoryExternalId,string ip,string code,DateTime startDate,DateTime endDate);

        Task<List<DoseWa>?> GetDosesWaWithResult(int factoryExternalId);
        Task SetDosesWaWithResult(List<DoseWa> dosesWa);
       
    }
}
