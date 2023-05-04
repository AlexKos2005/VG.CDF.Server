using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
{
   public interface IFactoryActionsInfoService : ICrudService<FactoryActionsInfoRequestDto, FactoryActionsInfoResponseDto, int>
    {
        Task<FactoryActionsInfoResponseDto?> GetByFactoryExternalId(int factoryExternalId);

        Task ChangeLastDateTimeConnection(int factoryExternalId, DateTime dateTime, DateTimeOffset dateTimeOffset);

        Task ChangeLastDateTimeReportSending(int factoryExternalId, DateTime dateTime, DateTimeOffset dateTimeOffset);
    }
}
