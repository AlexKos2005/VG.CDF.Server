using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Application.Dto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Application.TagReportTask.Commands;
using BreadCommunityWeb.Blz.Application.TagReportTask.Queries;
using BreadCommunityWeb.Blz.Application.WorkEmail.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreadCommunityWeb.Blz.Server.Controllers;

/// <summary>
/// Контроллер элеткронной почты
/// </summary>
[Route("api/[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
[ApiController]
public class WorkEmailController : Controller
{
    private readonly IWorkEmailService _workEmailService;
    public WorkEmailController(IWorkEmailService workEmailService)
    {
        _workEmailService = workEmailService;
    }
    /// <summary>
    /// Получить почту
    /// </summary>
    /// <returns></returns>
    [HttpGet(nameof(Get))]
    public async Task<ActionResult<List<WorkEmailDto>>> Get([FromQuery]GetWorkEmailsListQuery query, CancellationToken cts)
    {
        return Ok(await _workEmailService.Get(query,cts));
    }
    
    /// <summary>
    /// Создать почту
    /// </summary>
    /// <returns></returns>
    [HttpPost(nameof(Create))]
    public async Task<ActionResult<WorkEmailDto>> Create(CreateWorkEmailCommand command, CancellationToken cts)
    {
        return Ok(await _workEmailService.Create(command,cts));
    }
    
    /// <summary>
    /// Удалить почту
    /// </summary>
    /// <returns></returns>
    [HttpDelete(nameof(Delete))]
    public async Task<ActionResult<bool>> Delete(DeleteWorkEmailCommand command, CancellationToken cts)
    {
        return Ok(await _workEmailService.Delete(command,cts));
    }
    
    /// <summary>
    /// Обновить почту
    /// </summary>
    /// <returns></returns>
    [HttpPut(nameof(Update))]
    public async Task<ActionResult<WorkEmailDto>> Update(UpdateWorkEmailCommand command, CancellationToken cts)
    {
        return Ok(await _workEmailService.Update(command,cts));
    }
    
    /// <summary>
    /// Добавить почту в указанную задачу рассылки отчетов
    /// </summary>
    /// <returns></returns>
    [HttpPost(nameof(PutToTagReportTask))]
    public async Task<ActionResult<WorkEmailDto>> PutToTagReportTask(AddWorkEmailToTagReportTaskCommand command, CancellationToken cts)
    {
        return Ok(await _workEmailService.AddWorkEmailToTagReportTask(command,cts));
    }
}
