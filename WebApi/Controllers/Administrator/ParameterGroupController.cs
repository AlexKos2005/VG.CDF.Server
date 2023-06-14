using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Companies.Commands;
using VG.CDF.Server.Application.Companies.Queries;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ParameterGroups.Commands;
using VG.CDF.Server.Application.ParameterGroups.Queries;
using VG.CDF.Server.Application.Parameters.Commands;
using VG.CDF.Server.Application.Parameters.Queries;
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
public class ParameterGroupController : ControllerBase<GetParameterGroupsListQuery,
    CreateParameterGroupCommand, 
    UpdateParameterGroupCommand,
    DeleteParameterGroupCommand,
    ParameterGroupDto>
{
    public ParameterGroupController(IMediator mediator) : base(mediator)
    {
    }
}