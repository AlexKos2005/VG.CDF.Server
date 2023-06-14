using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Companies.Commands;
using VG.CDF.Server.Application.Companies.Queries;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Application.Projects.Queries;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.WebApi.Controllers.Administrator;

[Route("api/admin/[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
[ApiController]
public class ProjectController : ControllerBase<GetProjectsListQuery,CreateProjectCommand, UpdateProjectCommand,DeleteProjectCommand,ProjectDto>
{
    public ProjectController(IMediator mediator) : base(mediator)
    {
    }
}