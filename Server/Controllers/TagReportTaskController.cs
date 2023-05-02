using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Application.Dto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Application.TagReportTask.Commands;
using BreadCommunityWeb.Blz.Application.TagReportTask.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreadCommunityWeb.Blz.Server.Controllers;

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
    public async Task<ActionResult<List<TagReportTaskDto>>> Get([FromQuery]GetTagReportTasksListQuery query, CancellationToken cts)
    {
        return Ok(await _reportTaskService.Get(query,cts));
    }
    
    /// <summary>
    /// Создать задачу по отчетам
    /// </summary>
    /// <returns></returns>
    [HttpPost(nameof(Create))]
    public async Task<ActionResult<TagReportTaskDto>> Create(CreateTagReportTaskCommand command, CancellationToken cts)
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
    public async Task<ActionResult<TagReportTaskDto>> Update(UpdateTagReportTaskCommand command, CancellationToken cts)
    {
        return Ok(await _reportTaskService.Update(command,cts));
    }
}
