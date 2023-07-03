using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.AlarmEvents.Commands;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Extentions;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.ProcessDescriptions.Commands;

public class UpdateProcessDescriptionCommand : EntityBaseDto,IRequest<ProcessDescriptionDto>
{
    public string RusDescription { get; set; } = String.Empty;
        
    public string EngDescription { get; set; }= String.Empty;
        
    public string UkrDescription { get; set; }= String.Empty;
    public Guid ProcessId { get; set; }

    public class UpdateAlarmEventDescriptionCommandHandler : UpdateCommandBase<UpdateProcessDescriptionCommand,ProcessDescriptionDto, ProcessDescription>
    {
        public UpdateAlarmEventDescriptionCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateProcessDescriptionCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateProcessDescriptionCommandValidator : AbstractValidator<UpdateProcessDescriptionCommand>
    {
        public UpdateProcessDescriptionCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Process>()
                    .EntityIsExists(command.ProcessId);
            }).WithMessage(command=> $"Процесса с Id {command.ProcessId} не существует");
        }
    }
}