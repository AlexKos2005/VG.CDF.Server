using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VG.CDF.Server.WebApi.Controllers
{
    /// <summary>
    /// Роли
    /// </summary>
    [Route("api/admin/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet(nameof(GetAllRoles))]
        public async Task<ActionResult<List<RoleResponseDto>>> GetAllRoles()
        {
            return Ok(await _roleService.GetAllRolesWithResult());
        }

        [HttpPost(nameof(PostRole))]
        public async Task<ActionResult> PostRole(RoleRequestDto roleDto)
        {
            await _roleService.Save(roleDto);
            return Ok();
        }

      
    }
}
