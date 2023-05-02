using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
   public interface IFactoryActionsInfoService : ICrudService<FactoryActionsInfoRequestDto, FactoryActionsInfoResponseDto, int>
    {
        Task<FactoryActionsInfoResponseDto?> GetByFactoryExternalId(int factoryExternalId);

        Task ChangeLastDateTimeConnection(int factoryExternalId, DateTime dateTime, DateTimeOffset dateTimeOffset);

        Task ChangeLastDateTimeReportSending(int factoryExternalId, DateTime dateTime, DateTimeOffset dateTimeOffset);
    }
}
