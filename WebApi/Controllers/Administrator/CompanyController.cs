using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Companies.Commands;
using VG.CDF.Server.Application.Companies.Queries;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.WebApi.Controllers.Administrator;

[Route("api/admin/[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType( StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ApiController]
public class CompanyController : ControllerBase<GetCompaniesListQuery,CreateCompanyCommand, UpdateCompanyCommand,DeleteCompanyCommand,CompanyDto>
{
    public CompanyController(IMediator mediator) : base(mediator)
    {
    }
}