﻿using System;
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

namespace VG.CDF.Server.Application.ProcessDescriptions.Commands;

public class CreateProcessDescriptionCommand : IRequest<ProcessDescriptionDto>
{
    public string RusDescription { get; set; } = String.Empty;
        
    public string EngDescription { get; set; }= String.Empty;
        
    public string UkrDescription { get; set; }= String.Empty;
    
    public Guid ProcessId { get; set; }

    public class CreateAlarmEventDescriptionCommandHandler : CreateCommandBase<CreateProcessDescriptionCommand,ProcessDescriptionDto, ProcessDescription>
    {
        public CreateAlarmEventDescriptionCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateProcessDescriptionCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateProcessDescriptionCommandValidator : AbstractValidator<CreateProcessDescriptionCommand>
    {
        public CreateProcessDescriptionCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Process>()
                    .EntityIsExists(command.ProcessId);
            }).WithMessage(command=> $"Процесса с Id {command.ProcessId} не существует");
            
            
        }
    }
}