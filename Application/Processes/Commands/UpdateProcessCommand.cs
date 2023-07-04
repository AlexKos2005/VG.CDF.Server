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

namespace VG.CDF.Server.Application.Processes.Commands;

public class UpdateProcessCommand : EntityBaseDto,IRequest<ProcessDto>
{
    public int ExternalId { get; set; }
    public int DeviceCode { get; set; }
    public string DeviceIp { get; set; } = string.Empty;
    public Guid ProjectId { get; set; }

    public class UpdateProcessCommandHandler : UpdateCommandBase<UpdateProcessCommand,ProcessDto, Process>
    {
        public UpdateProcessCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateProcessCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateProcessCommandValidator : AbstractValidator<UpdateProcessCommand>
    {
        public UpdateProcessCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Process>()
                    .EntityIsExists(command.Id);
                
            }).WithMessage(command=> $"Процесс с Id {command.Id} не существует");
            
        }
    }
}