using System;
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

namespace VG.CDF.Server.Application.Parameters.Commands;

public class CreateParameterCommand : IRequest<ParameterDto>
{
    public int ExternalId { get; set; }

    public ParameterValueType ValueType { get; set; }
        
    public Guid CompanyId { get; set; }

    public Guid ParameterGroupId { get; set; }

    public class CreateParameterCommandHandler : CreateCommandBase<CreateParameterCommand,ParameterDto, Parameter>
    {
        public CreateParameterCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateParameterCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateParameterCommandValidator : AbstractValidator<CreateParameterCommand>
    {
        public CreateParameterCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c.ExternalId).GreaterThan(0)
                .WithMessage("Внешний идентификатор параметра должен быть больше нуля");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Company>()
                    .EntityIsExists(command.CompanyId);
            }).WithMessage(command=> $"Компании с Id {command.CompanyId} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<ParameterGroup>()
                    .EntityIsExists(command.ParameterGroupId);
            }).WithMessage(command=> $"Группы параметров с Id {command.ParameterGroupId} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<Parameter>()
                    .Where(c => c.ExternalId == command.ExternalId && c.CompanyId == command.CompanyId).AnyAsync();
            }).WithMessage(command=> $"Parameter с указанным внеш. идентификатором уже существует в данной компании");
            
        }
    }
}