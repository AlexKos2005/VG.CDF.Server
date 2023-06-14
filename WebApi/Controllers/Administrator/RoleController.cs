using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Roles.Commands;
using VG.CDF.Server.Application.Roles.Queries;
using VG.CDF.Server.Application.Users.Commands;
using VG.CDF.Server.Application.Users.Queries;

namespace VG.CDF.Server.WebApi.Controllers.Administrator;

[Route("api/admin/[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
[ApiController]
public class RoleController : ControllerBase<GetRolesListQuery,CreateRoleCommand, UpdateRoleCommand,DeleteRoleCommand,RoleDto>
{
    public RoleController(IMediator mediator) : base(mediator)
    {
    }
}