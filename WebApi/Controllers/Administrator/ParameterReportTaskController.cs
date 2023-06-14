using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ParameterReportTasks.Commands;
using VG.CDF.Server.Application.ParameterReportTasks.Queries;
using VG.CDF.Server.Application.Users.Commands;
using VG.CDF.Server.Application.Users.Queries;

namespace VG.CDF.Server.WebApi.Controllers.Administrator;

[Route("api/admin/[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
[ApiController]
public class ParameterReportTaskController : 
    ControllerBase<GetParameterReportTasksListQuery,
        CreateParameterReportTaskCommand, 
        UpdateParameterReportTaskCommand,
        DeleteParameterReportTaskCommand,
        ParameterReportTaskDto>
{
    public ParameterReportTaskController(IMediator mediator) : base(mediator)
    {
    }
}