using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.RequestDto.Registration;
using VG.CDF.Server.Application.Extentions;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Application.Roles.Commands;
using VG.CDF.Server.Application.Roles.Queries;
using VG.CDF.Server.Application.Users.Commands;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VG.CDF.Server.WebApi.Controllers.Registration
{
    ///<summary>
    ///Регистрация
    ///</summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public SignUpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userRegistrationRequestDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Registrate(CreateUserCommand сreateUserCommand)
        {
            RoleDto role;
            var initialRoles = await _mediator.Send(new GetRolesListQuery(){RoleCode = RoleCode.None});

            if (initialRoles.Any() == false)
            {
                role = await _mediator.Send(new CreateRoleCommand() { RoleCode = RoleCode.None, RoleName = "InitialUser" });
            }
            else
            {
                role = initialRoles.First();
            }

            сreateUserCommand.RoleId = role.Id;

            await _mediator.Send(сreateUserCommand);

            return Ok();
        }


    }
}
