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

namespace VG.CDF.Server.Application.ParameterGroups.Commands;

public class UpdateParameterGroupCommand : EntityBaseDto,IRequest<ParameterGroupDto>
{
    public int ExternalId { get; set; }

    public string Name { get; set; } = string.Empty;

    public class UpdateParameterGroupCommandHandler : UpdateCommandBase<UpdateParameterGroupCommand,ParameterGroupDto, ParameterGroup>
    {
        public UpdateParameterGroupCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateParameterGroupCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateParameterGroupCommandValidator : AbstractValidator<UpdateParameterGroupCommand>
    {
        public UpdateParameterGroupCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c.ExternalId).GreaterThan(0)
                .WithMessage("Внешний идентификатор группы параметров должен быть больше нуля");
            
            RuleFor(c => c.Name).NotEmpty()
                .WithMessage("Название группы параметров не может быть пустым");

            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<ParameterGroup>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Группы параметров с Id {command.Id} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<ParameterGroup>()
                    .Where(c => c.ExternalId == command.ExternalId).AnyAsync();
            }).WithMessage(command=> $"Группа параметров с указанным внеш. идентификатором {command.ExternalId} уже существует");
            
        }
    }
}