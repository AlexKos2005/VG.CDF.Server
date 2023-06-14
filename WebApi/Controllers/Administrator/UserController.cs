using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Users.Commands;
using VG.CDF.Server.Application.Users.Queries;

namespace VG.CDF.Server.WebApi.Controllers.Administrator;

[Route("api/admin/[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
[ApiController]
public class UserController : ControllerBase<GetUsersListQuery,CreateUserCommand, UpdateUserCommand,DeleteUserCommand,UserDto>
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }
}