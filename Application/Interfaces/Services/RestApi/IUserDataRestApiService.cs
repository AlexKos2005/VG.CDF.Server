using BreadCommunityWeb.Blz.Application.Dto.Client;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services.RestApi
{
    public interface IUserDataRestApiService
    {
        Task<List<FactoryResponseDto>> GetUserFactories(GetUserFactoriesRequestDto userRequestDto);

        Task<List<DeviceWithDescriptionsDto>> GetUserDevices(int factoryId);

        Task<List<TagParamWithDescriptions>> GetTagParamsForDevice(int deviceId);

        Task<List<LanguageResponseDto>> GetLanguages();

        Task<HttpResponseMessage> GetTagsReport(TagParamsReportDataInfo reportDataInfo);

        Task<HttpResponseMessage> GetAlarmEventsReport(AlarmEventsReportDataInfo reportDataInfo);

        Task<HttpResponseMessage> GetTagsExcelData(TagParamsReportDataInfo reportDataInfo);
    }
}
