using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.ParameterGroups.Commands;

public class CreateParameterGroupCommand : IRequest<ParameterGroupDto>
{
    public int ExternalId { get; set; }

    public string Name { get; set; } = string.Empty;

    public class CreateParameterGroupCommandHandler : CreateCommandBase<CreateParameterGroupCommand,ParameterGroupDto, ParameterGroup>
    {
        public CreateParameterGroupCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateParameterGroupCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateParameterGroupCommandValidator : AbstractValidator<CreateParameterGroupCommand>
    {
        public CreateParameterGroupCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c.ExternalId).GreaterThan(0)
                .WithMessage("Внешний идентификатор группы параметров должен быть больше нуля");
            
            RuleFor(c => c.Name).NotEmpty()
                .WithMessage("Название группы параметров не может быть пустым");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<ParameterGroup>()
                    .Where(c => c.ExternalId == command.ExternalId).AnyAsync();
            }).WithMessage(command=> $"Группа параметров с внещ. идентификатором {command.ExternalId} уже существует");
            
        }
    }
}