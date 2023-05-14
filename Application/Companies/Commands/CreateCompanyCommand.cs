using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Companies.Commands;

public class CreateCompanyCommand : IRequest<CompanyDto>
{
    public string Name { get; set; } = string.Empty;

    public class CreateCompanyCommandHandler : CreateCommandBase<CreateCompanyCommand,CompanyDto, Company>
    {
        public CreateCompanyCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateCompanyCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateCmpanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCmpanyCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<Company>()
                    .Where(c => c.Name.ToLower() == command.Name.ToLower()).AnyAsync();
            }).WithMessage(command=> $"Компания с указанным именем уже существует");
            
        }
    }
}