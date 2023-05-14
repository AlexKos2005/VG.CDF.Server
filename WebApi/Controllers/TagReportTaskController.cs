using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Application.TagReportTask.Commands;
using VG.CDF.Server.Application.TagReportTask.Queries;

namespace VG.CDF.Server.WebApi.Controllers;

/// <summary>
/// Контроллер задачи по отчетам
/// </summary>

[Route("api/[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
[ApiController]
public class TagReportTaskController : Controller
{
    private readonly ITagReportTaskService _reportTaskService;
    public TagReportTaskController(ITagReportTaskService reportTaskService)
    {
        _reportTaskService = reportTaskService;
    }
    /// <summary>
    /// Получить задачи по отчетам
    /// </summary>
    /// <returns></returns>
    [HttpGet(nameof(Get))]
    public async Task<ActionResult<List<ParameterReportTaskDto>>> Get([FromQuery]GetTagReportTasksListQuery query, CancellationToken cts)
    {
        return Ok(await _reportTaskService.Get(query,cts));
    }
    
    /// <summary>
    /// Создать задачу по отчетам
    /// </summary>
    /// <returns></returns>
    [HttpPost(nameof(Create))]
    public async Task<ActionResult<ParameterReportTaskDto>> Create(CreateTagReportTaskCommand command, CancellationToken cts)
    {
        return Ok(await _reportTaskService.Create(command,cts));
    }
    
    /// <summary>
    /// Удалить задачу по отчетам
    /// </summary>
    /// <returns></returns>
    [HttpDelete(nameof(Delete))]
    public async Task<ActionResult<bool>> Delete(DeleteTagReportTaskCommand command, CancellationToken cts)
    {
        return Ok(await _reportTaskService.Delete(command,cts));
    }
    
    /// <summary>
    /// Обновить задачу по отчетам
    /// </summary>
    /// <returns></returns>
    [HttpPut(nameof(Update))]
    public async Task<ActionResult<ParameterReportTaskDto>> Update(UpdateTagReportTaskCommand command, CancellationToken cts)
    {
        return Ok(await _reportTaskService.Update(command,cts));
    }
}
