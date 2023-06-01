using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Processes.Commands;

public class CreateProcessCommand : IRequest<ProcessDto>
{
    public int ExternalId { get; set; }
    public int DeviceCode { get; set; }
    public string DeviceIp { get; set; } = string.Empty;
    public Guid ProjectId { get; set; }

    public class CreateProcessCommandHandler : CreateCommandBase<CreateProcessCommand,ProcessDto, Process>
    {
        public CreateProcessCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateProcessCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateProcessCommandValidator : AbstractValidator<CreateProcessCommand>
    {
        public CreateProcessCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c.ExternalId).GreaterThan(0)
                .WithMessage("Внешний идентификатор процесса должен быть больше нуля");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<Process>()
                    .Where(c => c.ExternalId == command.ExternalId && c.ProjectId == command.ProjectId).AnyAsync();
            }).WithMessage(command=> $"Процесс с указанным внеш. идентификатором уже существует");
            
        }
    }
}