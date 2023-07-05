using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Companies.Commands;
using VG.CDF.Server.Application.Companies.Queries;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Processes.Commands;
using VG.CDF.Server.Application.Processes.Queries;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Application.Projects.Queries;
using VG.CDF.Server.Application.WorkEmails.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.WebApi.Controllers.Administrator;

[Route("api/admin/[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
[ApiController]
public class ProcessController : ControllerBase<GetProcessesListQuery,
    CreateProcessCommand, 
    UpdateProcessCommand,
    DeleteProcessCommand,
    ProcessDto>
{
    public ProcessController(IMediator mediator) : base(mediator)
    {
    }
    
    
    /// <summary>
    /// Добавить параметры в процесс (добавляются только отсутствующие)
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cts"></param>
    /// <returns></returns>
    [HttpPost(nameof(AddParametersToProcess))]
    public async Task<bool> AddParametersToProcess([FromBody]AddParametersToProcessCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        return result;
    }
    
    
    /// <summary>
    /// Удалить параметры из процесса
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cts"></param>
    /// <returns></returns>
    [HttpDelete(nameof(DeleteParameterFromProcess))]
    public async Task<IActionResult> DeleteParameterFromProcess([FromBody]DeleteParameterFromProcessCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        return NoContent();
    }
}