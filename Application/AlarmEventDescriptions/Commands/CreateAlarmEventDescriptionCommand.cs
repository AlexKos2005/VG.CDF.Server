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

namespace VG.CDF.Server.Application.AlarmEventDescriptions.Commands;

public class CreateAlarmEventDescriptionCommand : EntityBaseDto,IRequest<AlarmEventDescriptionDto>
{
    public string Description { get; set; }

    public Guid AlarmEventId { get; set; }
    
    public Guid DescriptionsLanguageId { get; set; }

    public class CreateAlarmEventDescriptionCommandHandler : CreateCommandBase<CreateAlarmEventDescriptionCommand,AlarmEventDescriptionDto, AlarmEventDescription>
    {
        public CreateAlarmEventDescriptionCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateAlarmEventDescriptionCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateAlarmEventCommandValidator : AbstractValidator<CreateAlarmEventDescriptionCommand>
    {
        public CreateAlarmEventCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<AlarmEventDescription>()
                    .Where(c => c.AlarmEventId == command.AlarmEventId).AnyAsync();
            }).WithMessage(command=> $"Аварийного события с Id {command.AlarmEventId} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<AlarmEventDescription>()
                    .Where(c => c.LanguageId == command.DescriptionsLanguageId).AnyAsync();
            }).WithMessage(command=> $"Языкового описания с Id {command.DescriptionsLanguageId} не существует");
            
        }
    }
}