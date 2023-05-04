using AutoMapper;

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
    /// Действия пользователя
    /// </summary>
    [Route("api/admin/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IFactoryService _factoryService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService,IRoleService roleService, IFactoryService factoryService, IMapper mapper)
        {
            _userService = userService;
            _roleService = roleService;
            _factoryService = factoryService;
            _mapper = mapper;
        }
        /// <summary>
        /// Получить всех пользователей в системе
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllUsers))]
        public async Task<ActionResult<List<UserResponseDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Установть роль пользователю
        /// </summary>
        /// <returns></returns>
        [HttpPut(nameof(PutRoleForUser))]
        public async Task<ActionResult> PutRoleForUser(int userId,int roleId)
        {
            var role = await _roleService.Get(roleId);
           
            if(role == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }


            user.Role = role;
            var userRequest = _mapper.Map<UserRequestDto>(user);
            await _userService.UpdateUserById(userId, userRequest);
            return Ok();
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteUser))]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserById(id);
            return Ok();
        }

        /// <summary>
        /// Добавить предприятие пользователю
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(AddFactoryForUser))]
        public async Task<ActionResult> AddFactoryForUser(int userId,int factoryId)
        {
            await _userService.AddFactory(userId, factoryId);
            return Ok();
        }
    }
}
