using System.Threading.Tasks;
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
public class AlarmEventReportController : Controller
{
    private readonly IReportDataService<AlarmEventsReportDataInfo> _paramReportService;
    public AlarmEventReportController(IReportDataService<AlarmEventsReportDataInfo> paramReportService)
    {
        _paramReportService = paramReportService;
    }
    
    /// <summary>
    /// Сгенерировать отчет по реал-тайм авариям
    /// </summary>
    /// <returns></returns>
    [HttpPost(nameof(GetAlarmEventsLiveReport))]
    public async Task<FileContentResult> GetAlarmEventsLiveReport(AlarmEventsReportDataInfo reportDataInfo)
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