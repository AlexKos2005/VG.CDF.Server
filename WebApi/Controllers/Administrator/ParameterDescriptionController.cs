using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Companies.Commands;
using VG.CDF.Server.Application.Companies.Queries;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ParameterDescriptions.Commands;
using VG.CDF.Server.Application.ParameterDescriptions.Queries;
using VG.CDF.Server.Application.ProcessDescriptions.Commands;
using VG.CDF.Server.Application.ProcessDescriptions.Queries;
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
public class ParameterDescriptionController : ControllerBase<GetParameterDescriptionsListQuery,
    CreateParameterDescriptionCommand, 
    UpdateParameterDescriptionCommand,
    DeleteParameterDescriptionCommand,
    ParameterDescriptionDto>
{
    public ParameterDescriptionController(IMediator mediator) : base(mediator)
    {
    }
}