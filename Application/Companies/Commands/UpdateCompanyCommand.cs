using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Extentions;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Companies.Commands;

public class UpdateCompanyCommand : EntityBaseDto,IRequest<CompanyDto>
{
    public string Name { get; set; } = string.Empty;

    public class UpdateCompanyCommandHandler : UpdateCommandBase<UpdateCompanyCommand,CompanyDto, Company>
    {
        public UpdateCompanyCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateCompanyCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Company>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Компании с Id {command.Id} не существует");
            
        }
    }
}