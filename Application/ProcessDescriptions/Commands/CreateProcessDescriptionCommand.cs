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

namespace VG.CDF.Server.Application.ProcessDescriptions.Commands;

public class CreateProcessDescriptionCommand : EntityBaseDto,IRequest<ProcessDescriptionDto>
{
   
    public string Description { get; set; } = string.Empty;

    public Guid LanguageId { get; set; }
        
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
                return await dataContext.Set<ProcessDescription>()
                    .Where(c => c.ProcessId == command.ProcessId).AnyAsync();
            }).WithMessage(command=> $"Процесса с Id {command.ProcessId} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<ProcessDescription>()
                    .Where(c => c.LanguageId == command.LanguageId).AnyAsync();
            }).WithMessage(command=> $"Языкового описания с Id {command.LanguageId} не существует");
            
        }
    }
}