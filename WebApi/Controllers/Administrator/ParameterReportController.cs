﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Infrastructure.Services;

namespace VG.CDF.Server.WebApi.Controllers.Administrator;

/// <summary>
/// Контроллер генерации отчетов
/// </summary>
[Route("api/admin/[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
[ApiController]
public class ParameterReportController : Controller
{
    private readonly IReportDataService<ProcessParametersReportDataInfo> _paramReportService;
    public ParameterReportController(IReportDataService<ProcessParametersReportDataInfo> paramReportService)
    {
        _paramReportService = paramReportService;
    }
    
    /// <summary>
    /// Сгенерировать отчет по реал-тайм значений параметров
    /// </summary>
    /// <returns></returns>
    [HttpPost(nameof(GetParameterValuesReport))]
    public async Task<FileContentResult> GetParameterValuesReport(ProcessParametersReportDataInfo reportDataInfo)
    {
        var package = await _paramReportService.GetExcelReportData(reportDataInfo);

        var excelReportService = new ExcelReportService(package);
        var report = excelReportService.MakeReport();

        var bytes = await report.GetAsByteArrayAsync();

        var file = new FileContentResult(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        file.FileDownloadName = $"{package.ExcelFileName}.xlsx";


        return file;
    }
}