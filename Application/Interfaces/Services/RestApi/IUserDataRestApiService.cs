using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services.RestApi
{
    public interface IUserDataRestApiService
    {
        Task<List<FactoryResponseDto>> GetUserFactories(GetUserFactoriesRequestDto userRequestDto);

        Task<List<ProcessWithDescriptionsDto>> GetUserDevices(int factoryId);

        Task<List<ParametersWithDescriptions>> GetTagParamsForDevice(int deviceId);

        Task<List<LanguageResponseDto>> GetLanguages();

        Task<HttpResponseMessage> GetTagsReport(ProcessParametersReportDataInfo reportDataInfo);

        Task<HttpResponseMessage> GetAlarmEventsReport(AlarmEventsReportDataInfo reportDataInfo);

        Task<HttpResponseMessage> GetTagsExcelData(ProcessParametersReportDataInfo reportDataInfo);
    }
}
