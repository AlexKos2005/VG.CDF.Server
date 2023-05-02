using BreadCommunityWeb.Blz.Application.Dto.Client;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Application.Models.ExcelModels;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Domain.Enums;
using BreadCommunityWeb.Blz.Infrastructure.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Server.Controllers
{
    ///<summary>
    ///Отчеты
    ///</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportDataService<TagParamsReportDataInfo> _tagsReportDataService;
        private readonly IReportDataService<AlarmEventsReportDataInfo> _alarmEventsReportDataService;

        public ReportController(
            IReportDataService<TagParamsReportDataInfo> reportDataService,
            IReportDataService<AlarmEventsReportDataInfo> alarmEventsReportDataService
           )
        {
            _tagsReportDataService = reportDataService;
            _alarmEventsReportDataService = alarmEventsReportDataService;
        }

        /// <summary>
        /// Сгенерировать отчет
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(CreateReport))]
        public async Task<FileContentResult> CreateReport(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate)
        {
            var package = await _tagsReportDataService.GetExcelReportData(factoryExternalId, deviceExternalId, startDate, endDate,1);

            var excelReportService = new ExcelReportService(package);
            var report = excelReportService.MakeReport();

            var bytes = await report.GetAsByteArrayAsync();

            var file = new FileContentResult(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            file.FileDownloadName = $"{package.ExcelFileName}.xlsx";

          
            return file;
        }

        ///// <summary>
        ///// Сгенерировать отчет
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet(nameof(GetReport))]
        //public async Task<FileContentResult> GetReport()
        //{
        //    var package = await _reportDataService.GetExcelReportData(10101, 1, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(2), 1);

        //    var excelReportService = new ExcelReportService(package);
        //    var report = excelReportService.MakeReport();

        //    var bytes = await report.GetAsByteArrayAsync();

        //    var file = new FileContentResult(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        //    file.FileDownloadName = $"{package.ExcelFileName}.xlsx";


        //    return file;
        //}


        /// <summary>
        /// Сгенерировать отчет по реал-тайм тегам
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetTagsLiveReport))]
        public async Task<FileContentResult> GetTagsLiveReport(TagParamsReportDataInfo reportDataInfo)
        {
            var package = await _tagsReportDataService.GetExcelReportData(reportDataInfo);

            var excelReportService = new ExcelReportService(package);
            var report = excelReportService.MakeReport();

            var bytes = await report.GetAsByteArrayAsync();

            var file = new FileContentResult(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            file.FileDownloadName = $"{package.ExcelFileName}.xlsx";


            return file;
        }

        /// <summary>
        /// Сгенерировать отчет по реал-тайм аварийным сообщениям
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetAlarmEventsLiveReport))]
        public async Task<FileContentResult> GetAlarmEventsLiveReport(AlarmEventsReportDataInfo reportDataInfo)
        {
            var package = await _alarmEventsReportDataService.GetExcelReportData(reportDataInfo);

            var excelReportService = new ExcelReportService(package);
            var report = excelReportService.MakeReport();

            var bytes = await report.GetAsByteArrayAsync();

            var file = new FileContentResult(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            file.FileDownloadName = $"{package.ExcelFileName}.xlsx";


            return file;
        }



        /// <summary>
        /// Сгенерировать данные по тегам за период
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetTagsLiveExcelData))]
        public async Task<ExcelReportData> GetTagsLiveExcelData(TagParamsReportDataInfo reportDataInfo)
        {
            var package = await _tagsReportDataService.GetExcelReportData(reportDataInfo);

            return package;
        }
    }
}
