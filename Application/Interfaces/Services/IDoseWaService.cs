using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
   public interface IDoseWaService
    {
        Task<List<DoseWaResponseDto>> GetDosesWaByEnterpriseUIdAndDatesWithResult(int factoryExternalId, string ip, string code, DateTime startDate, DateTime endDate);

        Task<List<DoseWaResponseDto>?> GetDosesWaWithResult(int factoryExternalId);
        Task SetDosesWaWithResult(List<DoseWaRequestDto> dosesWa);
    }
}
