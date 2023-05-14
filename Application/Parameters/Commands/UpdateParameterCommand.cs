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

public class UpdateParameterCommand : EntityBaseDto,IRequest<ParameterDto>
{
    public int ExternalId { get; set; }

    public ParameterValueType ValueType { get; set; }
        
    public Guid CompanyId { get; set; }

    public Guid ParameterGroupId { get; set; }

    public class UpdateParameterCommandHandler : UpdateCommandBase<UpdateParameterCommand,ParameterDto, Parameter>
    {
        public UpdateParameterCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateParameterCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateParameterCommandValidator : AbstractValidator<UpdateParameterCommand>
    {
        public UpdateParameterCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<Parameter>()
                    .Where(c => c.ExternalId == command.ExternalId).AnyAsync();
            }).WithMessage(command=> $"Параметр с внеш. идентификатором уже существует у данной компании");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Parameter>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Параметр с Id {command.Id} не существует");
            
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
            
        }
    }
}