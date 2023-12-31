﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces.Services;

namespace VG.CDF.Server.WebApi.Controllers.ExternalService;

[Route("api/external/[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
public class ParameterValuesGroupController : Controller
{
    private ISaveable<ParameterValuesGroupDto> _saveableService;
    public ParameterValuesGroupController(ISaveable<ParameterValuesGroupDto> saveableService)
    {
        _saveableService = saveableService;
    }
    
    [HttpPost("SaveGroups")]
    public async Task<IActionResult> Create([FromBody] IEnumerable<ParameterValuesGroupDto> parameterValuesGroups)
    {
        await _saveableService.Save(parameterValuesGroups);

        return Ok();
    }
}