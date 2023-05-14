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

public class DeleteCompanyCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteCompanyCommandHandler : DeleteCommandBase<DeleteCompanyCommand, Company>
    {
        public DeleteCompanyCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteCompanyCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Company>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Компании с Id {command.Id} не существует");
            
        }
    }
}